using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Locker
{
    class Locker
    {
        private String lockedFolder = "Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D}";
        private String unlockedFolder = "Locker";
        private String passwordFile = "password.txt";
        //private String readmeFile = "Readme.txt";     //------------ OLD FEATURE --------------------
        /*Readme.txt used to be txt file where user could read information about the app and its usage.
        It's no longer needed since popup messages and "About" button on menu*/
        private String passwordToCheck;
        private String passwordToCompare;
        public String aboutText = "This executable will always make new Locker folder in directory you start it.\n\n" +
                "Do not delete any program files/folders manually exept the readme file.\n\n" +
                "If you want to delete files or stop using this program use the delete option from the menu so that all the hidden files will be removed too\n\n" +
                "Default password is: \"asd\".\n\n" +
                "Always close every file/executable/directory inside the Locker folder before locking it.\n\n" +
                "DO NOT FORGET YOUR PASSWORD WHEN YOU CHANGE IT\n\n" +
                "Created by Jani Kärkkäinen karkkainen91(a)gmail.com\n"+
                "Locker version 0.2";
        public Locker()
        {
            //Create folder and files if they dont exist
            if (!Directory.Exists(lockedFolder))
            {
                createFolderAndFiles();
            }
        }

        private void createFolderAndFiles()
        {
            //create Locker dir
            //create default password file
            Directory.CreateDirectory(unlockedFolder);
            if (!File.Exists(passwordFile))
            {
                
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(passwordFile))
                {
                    sw.Write("YXNk"); //default password (asd) in base64 written in file where users password is saved.
                }
                File.SetAttributes(passwordFile, File.GetAttributes(passwordFile) | FileAttributes.Hidden);
                File.SetAttributes(passwordFile, File.GetAttributes(passwordFile) | FileAttributes.System);

                /*
                //--------------------OLD READMEFILE CREATION----------------------
                using (StreamWriter SW = File.CreateText(readmeFile))
                {
                    SW.WriteLine(aboutText);         
                }*/

                System.Windows.Forms.MessageBox.Show("Seems like it's your first time opening this program, Thank you for your intrest!\n\n" + aboutText);
            }
            
        }

        public bool getPassword(String givenPassword)
        {
            //change given password into base64
            //compare givenpassword and savedpasword
            //return true/false
            var bytes = System.Text.Encoding.UTF8.GetBytes(givenPassword);
            passwordToCheck = System.Convert.ToBase64String(bytes);

            passwordToCompare = System.IO.File.ReadAllText(passwordFile);
            if (passwordToCheck == passwordToCompare)
            { return true; }
            else
            { return false; }
        }


        public void lockFolder()
        {
            //change Locker dir name -> Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D}
            //change Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D} attrib +h +s
            Directory.Move(unlockedFolder, lockedFolder);
            File.SetAttributes(lockedFolder, File.GetAttributes(lockedFolder) | FileAttributes.Hidden);
            File.SetAttributes(lockedFolder, File.GetAttributes(lockedFolder) | FileAttributes.System);
        }

        public void unlockFolder()
        {
            //change Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D} name -> Locker
            //change Locker attrib -s -h
            FileAttributes attributes = File.GetAttributes(lockedFolder);
            attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
            File.SetAttributes(lockedFolder, attributes);
            attributes = RemoveAttribute(attributes, FileAttributes.System);
            File.SetAttributes(lockedFolder, attributes);
            Directory.Move(lockedFolder, unlockedFolder);
        }

        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            //needed in many funcktions where you need to change attributes that file or directory has
            return attributes & ~attributesToRemove;
        }

        public void changePassword(String newPW)
        {
            //make passworrdFile accessable
            //change pasword.txt content
            //make passwordFile unaccessable
            FileAttributes attributes = File.GetAttributes(passwordFile);
            attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
            File.SetAttributes(passwordFile, attributes);
            attributes = RemoveAttribute(attributes, FileAttributes.System);
            File.SetAttributes(passwordFile, attributes);

            using (StreamWriter sw = File.CreateText(passwordFile))
            {
                sw.Flush();
                var bytes = System.Text.Encoding.UTF8.GetBytes(newPW);
                String newPassword = System.Convert.ToBase64String(bytes);
                sw.Write(newPassword);
            }
            File.SetAttributes(passwordFile, File.GetAttributes(passwordFile) | FileAttributes.Hidden);
            File.SetAttributes(passwordFile, File.GetAttributes(passwordFile) | FileAttributes.System);

        }

        public String status()
        {               
            //returns is folder locked or unlocked
                String s;
                if (Directory.Exists(lockedFolder))
                {
                    s = "Unlock";
                    return s;
                }
                else if (Directory.Exists(unlockedFolder))
                {
                    s = "Lock";
                    return s;
                }
            else { return null; }
        }

        public void deleteLockerFiles()
        {
            //deletes Control Panel.{21EC2020-3AEA-1069-A2DD-08002B30309D} folder
            //deletes Locker folder
            //deletes password.txt file
            //used to delete readme file
            if (Directory.Exists(lockedFolder))
            {
                FileAttributes attributes = File.GetAttributes(lockedFolder);
                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                File.SetAttributes(lockedFolder, attributes);
                attributes = RemoveAttribute(attributes, FileAttributes.System);
                File.SetAttributes(lockedFolder, attributes);
                Directory.Delete(lockedFolder,true);
            }
            if(Directory.Exists(unlockedFolder))
            {
                Directory.Delete(unlockedFolder,true);
            }
            if(File.Exists(passwordFile))
            {
                FileAttributes attributes = File.GetAttributes(passwordFile);
                attributes = RemoveAttribute(attributes, FileAttributes.Hidden);
                File.SetAttributes(passwordFile, attributes);
                attributes = RemoveAttribute(attributes, FileAttributes.System);
                File.SetAttributes(passwordFile, attributes);
                File.Delete(passwordFile);
            }

            /*
            //------------------OLD README FILE DELETE--------------------
            if(File.Exists(readmeFile))
            {
                File.Delete(readmeFile);
            }
            */

        }

        public String getPath()
        {
            //get exe path
            //parse .exe away
            //return 
            String p = System.Reflection.Assembly.GetEntryAssembly().Location;
            String delete = "Locker.exe";
            char delimiterCharacter = '\u005C';
            String[] parse = p.Split(delimiterCharacter);
            String finalPath = "";

            foreach (string s in parse)
            {
                if(s != delete)
                {
                    finalPath += s + '\u005C';
                }
                else
                {
                    finalPath += "Locker" + '\u005C';
                }
            }

            return finalPath;
        }
    }
}
