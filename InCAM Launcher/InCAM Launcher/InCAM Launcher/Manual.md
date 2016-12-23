
##<i class=" icon-th-list"></i>Index


<br><br>


[toc]


	
	
<br><br>
<br><br>
<i class="  icon-info"></i><font size="0.1pt">*This manual applies to ```DFM Quick Launcher``` v1.0.1 build-20150112*</font>
<br><br>
<br><br>








##<i class="  icon-file"></i>Introduction

###<i class=" icon-doc-text-inv"></i>Description
In our daily work, We have to do a lot of clicks before we can run an action. Generally we have to follow this sequence: ```Launch InCAM/Genesis/Geflex``` <i class=" icon-right-big"></i> ```Search for a job``` <i class=" icon-right-big"></i> ```Open a job``` <i class=" icon-right-big"></i> ```Select Step``` <i class=" icon-right-big"></i> ```Open Checklist```->```Set display and .affected layer``` <i class=" icon-right-big"></i> ```Run a action```. If the same action are repeated again and again , it becomes boring and time-wasting, so we make a automatic tool to help us get ride of the repeating work.

```DFM Quick Launcher``` helps us to automatize the repeating work,  it uses ```Session``` mechanism to remember user operations, once configured, it can leads us directly to the last step on next call.

The picture below shows a simple comparison of manual operation and automatic operation with ```DFM Quick Launcher```.            

![1](http://robots.shuyz.com/tmp/1.png)

###<i class=" icon-help"></i>How it works

```DFM Quick Launcher``` uses  ```InCAM```/ ```Genesis``` /```Geflex``` script API to automatize the job. 
On the first run, users have to choose a DFM tool, a job, a step, layers and checklist, these steps looks exactly the same with manual operation. 
Once done with these steps, everything is stored into a ```Session```. If we want to run the same action again next time, we can load the session and ```DFM Quick Launcher``` will handle the rest.
```Sessions``` are stored into files, so we can have many sessions to define different jobs and actions.
 
![1](http://robots.shuyz.com/tmp/2.png)

##<i class=" icon-download"></i>Installation

###<i class="  icon-right-hand"></i>Prerequisite
```DFM Quick Launcher``` needs ```Microsoft .NET Framework 4.5``` runtime. If you have installed ```Visual Studio 2012```, you already have it, otherwise you should [<i class="   icon-floppy"></i>DOANLOAD](http://www.microsoft.com/en-US/download/details.aspx?id=30653) and install it before install ```DFM Quick Launcher```.

###<i class=" icon-export-alt"></i>Exact files
```DFM Quick Launcher``` is a green software, which means it does not need any step by step installation. Just exact all files from the archive into ```C:\Launcher```, then create a shortcut to ```DFM Quick Launcher.exe``` on desktop.
><i class=" icon-info-circled"></i>**Note**
>Exact the files into other directory is also OK, but if the path contains special characters or space( for example: ```C:\Program Files\Launcher```), the application can not run properly.

##<i class=" icon-truck"></i>Get it to work
###<i class="  icon-wrench"></i>Configuration
There is a configuration file named ```Config``` located in the directory where ```DFM Quick Launcher``` is installed, use a text editor to edit it.
 ><i class=" icon-info-circled"></i>**Note**
 > Please Exit  ```DFM Quick Launcher```  before editing the configuration file, any changes to the file while ```DFM Quick Launcher```  is running will be reverted.

There are three section of configuration: ```MAIN```, ```DFM``` and ```COMMAND```.

- **MAIN**

	- **HideAfterLaunch**
    If enabled, the ```DFM Quick Launcher``` window will hide automatically when DFM is launched. 
    	    >Default: ```CloseCmdAfterRun=1```
    
	- **CloseCmdAfterRun**
    If enabled, the background windows will close automatically when DFM is exited; if disabled, the background window will stay after DFM is exited, we should close it manually, it;'s useful for debug.
	    >Default: ```CloseCmdAfterRun=1```
    
	- **MinimizedToTrayOnly**
    If enabled, we can only find ```DFM Quick Launcher``` in the notify area, it will hide from the taskbar; if disabled, we can find it on both notify area and taskbar.
    >Default: ```MinimizedToTrayOnly=1```
    
	- **HideOnClose**
    If enabled, when we click ```Exit``` icon of ```DFM Quick Launcher``` window, ```DFM Quick Launcher``` will not exit but minimize to notify area.
    >Default: ```HideOnClose=1```

- **DFM**
	- **XMANAGER**
	The full path of ```XMANAGER.EXE```, ```XMANAGER``` will be called before launch ```Genesis``` and ```Geflex```.
		> Default: ```XMANAGER=C:\Program Files (x86)\xmanager\XMANAGER.EXE```
    
    - **InCAMBase**
    Where ```InCAM``` versions are kept.
    >Default: ```InCAMBase=D:\InCAM```
    
    - **GenBase**
    Where ```Genesis/Geflex``` versions are kept.
    >Default: ```GenBase=D:\Genesis```
    
    - **InCAMVer**
    The default ```InCAM``` version path, this version can be launched from context menu of ```DFM Quick Launcher```.
    >Default: ```InCAMVer=D:\InCAM\release_64```
    
    - **GenVer**
    The default ```Genesis``` version path.
    >Default: ```GenVer=D:\Genesis\e98```
    
    - **GfxVer**
    The default ```Geflex``` version path.
    > Default: ```GfxVer=D:\Genesis\e98```

- **COMMAND**
	Run commands before DFM is launched, the function is designed to switch license between ```Genesis``` and ```Geflex```.
	If you want to run more than one command, use ```&```to combine multiple commands. for example ```echo 1 & echo 2```.
    - **RunBeforeInCAM**
    If you want to do anything before launch ```InCAM```, fill the comamnds here. default value is null.
    >Default: ```RunBeforeInCAM=```
    
    - **RunBeforeGenesis**
    Run commands before launch ```Genesis```. for example, we can put a command to replace liscense file.
    >Default: ```RunBeforeGenesis=copy d:\Genesis\share\license\GN00-91D8-53BF-CC31_g d:\Genesis\share\license\GN00-91D8-53BF-CC31```
    
    - **RunBeforeGeflex**
     Run commands before launch ```Geflex```.
    >Default: ```RunBeforeGeflex=copy d:\Genesis\share\license\GN00-91D8-53BF-CC31_gfx d:\Genesis\share\license\GN00-91D8-53BF-CC31```

###<i class="  icon-smile"></i>Have a try

Here is step by step guide to setup and launch a session.

1. Open ```DFM Quick Launcher```,  Select a directory for ```DFM Directory```. You can do it by input directly, click the dropdown button to select or click the ```Browse``` button.

    ![1](http://robots.shuyz.com/tmp/3.png)

   If the path is invalid, the text's color will become red.
   
  ![1](http://robots.shuyz.com/tmp/4.png)

2. Specify```InCAM``` or ```Genesis```/```Geflex``` DB path.
3. If DB path is valid, the jobs from the DB will be loaded into the job list. we can use a Filter to search for a job. you can use```wildcard``` like you do in ```InCAM```, or use ```regex``` for more accurate result.

	![1](http://robots.shuyz.com/tmp/5.png)

	><i class=" icon-info-circled"></i>**Note**
	>If you add/delete/change job name while ```DFM Quick Launcher``` is running, the joblist will not refresh automatically. To refresh the DB manually, you need to use the ```Refresh``` command on the context menu by one click with the right mouse key.
	
4. Fill in the ```Options``` areas.

	![1](http://robots.shuyz.com/tmp/6.png)
	
    - **DFM**
    Define what we want to launch. 
    ><i class=" icon-info-circled"></i>**Note**
    > ```InCAM``` will be automatically selected if  ```DFM Directory``` is defined for```InCAM```, but we are not able to distinguish between ```Genesis``` and ```Geflex```.
    
    - **Steps**
    - **Layer**
    The layer here will be set as display layer and .affected layer, *you can leave it empty if yo don't want to set .affect layer*.
    - **Checklist**
    Run a check list. *You can leave it empty if you do not want to open a checklist*.
    - **Run Checklist After Launch**
    If checked, ```DFM Quick Launcher``` will run the checklist automatically when DFM is launched.

5. Start the Session

    Click ```Launch``` Button, if everything goes OK, you'll be lead to the following page directly. A changelist is opened, and display layer are set.
    
	![1](http://robots.shuyz.com/tmp/7.png)    

6. Save it for later
    We can save everything we've defined into a session, so we can call it later without any configuration.
    
    ![1](http://robots.shuyz.com/tmp/8.png)

    If there is more than one session stored, we can select one from the list and launch it quickly.
    
   ![1](http://robots.shuyz.com/tmp/9.png)

    ><i class=" icon-info-circled"></i>**Note**
    If we have too many sessions defined, the session list will be to long to find what we want. in this case we can ```delete``` or ```archive``` some sessions that are not used again. 
    Select a session from the list, **Double click** the delete icon to delete the session,  **Double click** the archive icon to archive the session.
    We suggest to keep less than 10 sessions in the list.

###<i class=" icon-rocket"></i>Make it faster

```DFM Quick Launcher``` goes with a icon on notify area, which provides the quickest access to a session.

![1](http://robots.shuyz.com/tmp/10.png)

To make the icon always visiable on the notify area, goto ```Control Panel\\All Control Panel Items\\Notification Area Icons``` and set the behavior of ```DFM Quick Launcher``` to ```Show icon and notifications```.

![1](http://robots.shuyz.com/tmp/11.png)

We can access sessions with the one click on the three of mouse keys, different behaviors are assign to different mouse keys.

- **Right Key**
	Open a context menu.
	
     ![1](http://robots.shuyz.com/tmp/12.png)
     
     There are four sections on the context menu:
     1. System Command
     Show/ hide application window, exit application.
     2. DFM Shortcut
     Shorts for the most used version of ```InCAM```, ```Genesis``` and ```GeFlex```, the versions are defined in the config ```InCAMVer```, ```GenVer``` and ```GfxVer```.
     3. Session list
     A list of available sessions, click a session name to launch the session.
     ><i class=" icon-info-circled"></i>**Note**
     >The session list does not include the latest session launched before .
     
     4. Last Session
     The latest session launched before, the name will always stay close to the mouse so we can access it more quick.
     
- **Left Key**
    Click to Hide / Show ```DFM Quick Launcher```  window.

- **Middle Key**
    Launch the latest session with a rocket way! Just one click with the middle key, the last session will be launched.

##<i class="  icon-cancel"></i>Limitations
1. When run different version of ```Genesis``` / ```GeFlex```, it seems it runs the same version from the result.
```Genesis``` and ```GeFlex``` will always load progs in the directory defined with environment viable ```GENESIS_DIR``` and ```GENESIS_EDIR```. So if we run different versions of ```Genesis```, we are run the same version in ```GENESIS_DIR``` and ```GENESIS_EDIR``` actually.
We tried to set ```GENESIS_DIR``` and ```GENESIS_EDIR``` before launching ```Genesis```, However, it does not take affect unless a restart of the machine.

2. Some ```InCAM``` layer names and checklist names are not the same with what we see in ```InCAM```.
```DFM Quick Launcher``` parses directories for layers and checklists. the directories are not the same with what we get in ```InCAM```, so we'll get error layer names or checklists. In this case we can input the correct layer name and changelist name manually.

##<i class="   icon-help-circled"></i>Troubleshooting 

1. I modified my config file, it does not take affect.
While ```DFM Quick Launcher``` is running, any modification to the config will be reverted. Please close it before change any configuration.

2. Another instance is running.

  ![1](http://robots.shuyz.com/tmp/13.png)
  
  Another instance of ```DFM Quick Launcher``` is running, only one instance is allowed to run on one machine. Find it on the taskbar, notify area or task manager.
  
3. Invalid Path.
The installation directory is invalid, change it to another directory.

 ![1](http://robots.shuyz.com/tmp/14.png)

4. When launch a session, a background window flashes and nothing happened.
Close the application, change ```CloseCmdAfterRun``` to ```1``` in the configuration file, then start it again. The background window will show what's going on.

5. When I click ```Exit``` icon on the window, ```DFM Quick Launcher``` does not exit.
You can exit it by click ```Exit``` on the context menu from notify area.
Set ```HideOnClose``` to ```0``` and you can exit the application directly when click ```Exit``` icon on the window.

6. I can not find the application in the taskbar when minimized.
Set ``` MinimizedToTrayOnly``` to ```0``` and we can see it on both taskbar and notify area.

##<i class="    icon-list-numbered"></i>Todos
- Job Edit
    - Import
    - Export
    - Delete
- Automatic regression test
