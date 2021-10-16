# Native HTML for Windows

Native HTML is an easy and ultra lightweight wrapper for running web apps natively on windows.
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

# How It Works

The launcher is made with python. The launcher downloads the runtime libraries and runs it, telling it where the app files are located.
The runtime libraries are made in C# and do the majority of the work.
It starts an internal server on an available port, and connects to it using an instance of chromium.


# Performance

Since the Native HTML runtime library is made with C#, it has excellent performance.
Overall performance is better when put up against Chrome, Edge, Electron.js, and Opera(GX).
Your mileage may vary depending on your hardware.
Speed was tested with "http://www.speed-battle.com/speedtest_e.php".

![Native HTML beating Opera GX](https://github.com/SamarthCat/Native-HTML-for-Windows/blob/main/Images/Performance.png)
