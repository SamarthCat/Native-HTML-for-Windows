import os
import subprocess
from typing import Text
import win32gui, win32con
import requests
from zipfile import ZipFile
from io import BytesIO

workingDir = os.getcwd()
runtimeDir = "C:\\ProgramData\\SamsidParty\\Native-HTML\\Runtime"

#the_program_to_hide = win32gui.GetForegroundWindow()
#win32gui.ShowWindow(the_program_to_hide , win32con.SW_HIDE)


def showMessage(title, text):
    os.system("powershell -Command \"& {Add-Type -AssemblyName System.Windows.Forms; [System.Windows.Forms.MessageBox]::Show('" + text + "', '" + title + "', 'OK', [System.Windows.Forms.MessageBoxIcon]::Information);}\"")

def run():
    global workingDir
    global runtimeDir

    os.environ["Web-Run-Directory"] = workingDir + "\\Client"
    proc = subprocess.call(runtimeDir + "\\BrowserCSharp.exe")


def isConnected():
    cmd = os.system('ping google.com -w 4 > clear')
    if cmd == 0:
        return True
    else:
        return False

if (not os.path.isfile(runtimeDir + "\\BrowserCSharp.exe")):
    #Install Runtime Libraries
    if (isConnected()):
        print("Installing Libraries...")
        showMessage("Runtime Libraries Need To Update", "This may take a while the first time the app is launched, the app will start once the update is finished")
        if (not os.path.isdir("C:\\ProgramData\\SamsidParty\\Native-HTML")):
            os.makedirs("C:\\ProgramData\\SamsidParty\\Native-HTML")

        if (os.path.isdir(runtimeDir)):
            os.rmdir(runtimeDir)

        r = requests.get("https://github.com/SamarthCat/Native-HTML-for-Windows/releases/download/dependency/Runtime.zip")
        z = ZipFile(BytesIO(r.content))    
        z.extractall("C:\\ProgramData\\SamsidParty\\Native-HTML")
        run()
    else:
        showMessage("Runtime Libraries Need To Update", "Cannot update libraries due to a network error. Please check your internet connection.")
    
else:
    run()



