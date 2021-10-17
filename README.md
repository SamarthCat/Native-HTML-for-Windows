# Native HTML for Windows

Official Website: https://samsidparty.com/Software/Native%20HTML/native-html-for-windows.html

![Native HTML Demonstration](https://github.com/SamarthCat/Native-HTML-for-Windows/blob/main/Images/Thumbnail.png)

Native HTML is an easy and ultra-lightweight wrapper for running web apps natively on windows.
It is built on chromium with C# and python.

# Pros and Cons

|                                  Pros                                  | Cons                                                           |
|:----------------------------------------------------------------------:|----------------------------------------------------------------|
|                   Very small bundle size (about 8mb)                   |           Requires internet connection for first boot          |
|                       Easier to use than electron                      | Does not support deeper integration like microphone and camera |
|                   No building or compilation required                  |            Does not support native node.js functions           |
|      Supports features like sound, drag and drop, and file select      |                                                                |
|                 Supports custom icons and window titles                |                                                                |
| Excellent performance compared to other chromium browsers and electron |                                                                |
|      Ultra low memory usage (the default page uses less than 40mb)     |                                                                |

# How It Works

The launcher is made with python. It downloads the runtime libraries and runs it, telling it where the app files are located.
The runtime libraries are made in C# and do the majority of the work.
It starts an internal server on an available port, and connects to it using an instance of chromium.


# Performance

Since the Native HTML runtime library is made with C#, it has excellent performance.
Overall performance is better when put up against Chrome, Edge, Electron.js, and Opera(GX).
Your mileage may vary depending on your hardware.
Speed was tested with "http://www.speed-battle.com/speedtest_e.php".

![Native HTML beating Opera GX](https://github.com/SamarthCat/Native-HTML-for-Windows/blob/main/Images/Performance.png)

# Usage

Runtime Libraries are installed on first launch, therefore, users will need an internet connection when using the app for the first time. This is done to keep the bundle size low and so that only one *Runtime* folder is needed for all apps based on Native HTML.

Extract the latest release marked *App*, this will be the folder where all your app files will be, this will be the folder that you will publish, no building or compiling necessary.

Delete all the files in the *Client* folder, except for *mimetypes.txt*.

Import the files from your web app into the *Client* folder, ensure there is an *index.html* file present otherwise the app won't work.

If you want a custom runtime icon, place a *favicon.ico* file in the *Client* folder.

You can rename *client.exe* to your app's name, but attempting to change the icon may make it unusable. Instead, we recommend creating a shortcut for it at install time with a custom icon.

If you want to, you can compile *client.py* into an exe yourself with your own certificate. Make sure you delete *client.py* before shipping your app.
