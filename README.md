# Setting up the project

1. Install the latest version of Visual Studio
2. Open the projects solution (.sln) folder
3. For the purposes of testing, a folder called BUILD_OUTPUT is included which contains 10 DLL's with the following information:
   - My.First.Project.dll
   - My.Second.Project.dll
   - My.Third.Project.dll
   - My.Fourth.Project.dll
   - My.Fifth.Project.dll
   - Antlr3.runtime.dll
   - Newtonsoft.Json.dll
   - System.Web.Helpers.dll
   - System.Web.Mvc.dll
   - System.Web.Optimization.dll
   
   The folder also contains other non-dll files, and importantly, a text file called .dllTracker which contains a sample version sequence for the project files
   
   This folder must be used to test the application
   
4. For the purposes of testing, you may treate the pattern My.*.Project.dll as a project build, and everything else as either a non dll file or a dll third party file. Note that these project builds have the following version numbers:

   	   +---------------------+---------------------+
	   |DLL name             |Version              |
	   +---------------------+---------------------+
	   |My.First.Project.dll |3.5.0.2              |
	   +---------------------+---------------------+
	   |My.Second.Project.dll|6.0.0.0              |
	   +---------------------+---------------------+
	   |My.Third.Project.dll |6.0.0.0              |
	   +---------------------+---------------------+
	   |My.Fourth.Project.dll|2.0.1.0              |
	   +---------------------+---------------------+
	   |My.Fifth.Project.dll |1.0.0.0              |
	   +---------------------+---------------------+


# Usage Manual

1. Build and run the application
2. Enter the directory in which the version control tracking must occur
   
   For testing purposes, specify the directory to include the BUILD_OUTPUT folder supplied with this project
   
   Note that the path must be absolute and not relative, e.g.:
   
   C:\MyFile\MyOtherFile\BUILD_OUTPUT
   
3. This application is used, and works, in the following way:
   - After every project build, the output of those builds must be made into the BUILD_OUTPUT folder
   - The DLL tracker app must then be opened and the button "Version the Build" must be clicked
   - This adds the version contents of the BUILD_OUTPUT to a CSV file called .dllTracker
   - The .dllTracker file keeps track of the versions of the dll's in the file
   - Therefore, a build cycle would consist of the following cycle:
     
	 build project -> Open DLLTracker and click Version the Build -> build project -> Open DLLTracker and click Version the Build -> etc...
	 
	 By following this cycle, .dllTracker CSV file "grows" with the number of version sequences
	 
4. What's a valid version update anyway?
   - The test dll's included with the submission follow the De Facto assembly versioning standard, namely, \<major version\>.\<minor version\>.\<build number\>.\<revision\>
   - A valid project build update would include any change in version number such that the *overall* version number increases. To demonstrate this, consider the following examples:
5. Example of valid versions:

	   +---------------+---------------------+---------------+
	   |Old Version    |New Version          |Valid/Invalid? |
	   +---------------+---------------------+---------------+
	   |2.0.2.4        |2.0.2.5              |Valid          |
	   +---------------+---------------------+---------------+
	   |2.0.2.4        |3.0.0.0              |Valid          |
	   +---------------|---------------------+---------------+
	   |2.0.2.4        |2.0.5.2              |Valid          |
	   +---------------+---------------------+---------------+
	   |2.0.2.4        |1.0.2.2              |Invalid        | <-- version number regressed
	   +---------------|---------------------+---------------+
	   |2.0.2.4        |2.0.1.4              |Invalid        | <-- version number regressed
	   +---------------+---------------------+---------------+
	   |2.0.2.4        |2.0.2.4              |Invalid        | <-- version number remained the same
	   +---------------+---------------------+---------------+
	   
5. Catering for third party libraries
   - All project build outputs must be specified in the textbox under "List project names"
   - These names must be seperated by a newline and nothing else
   - Duplicates have no altering effect
   - Any file not included in this textbox is taken to be a third party library and will not be displayed as having potentially outdated libraries
6. To check for outdated libraries, click the "Check for Outdated Libraries" button; This will ensure that the DLL's with an invalid version number update will be shown
7. An analogy to the DLLTracker app may be found with the Git version control system with the following analogies:

	   +---------------+----------------------------------------------------+
	   |Git            |DLL Tracker                                         |
	   +---------------+----------------------------------------------------+
	   |.git folder    |.dllTracker file                                    |
	   +---------------+----------------------------------------------------+
	   |git commit     |Version the Build                                   |
	   +---------------+----------------------------------------------------+
	   |git ignore     |Any file not included in the List Project Names box |
	   +---------------+----------------------------------------------------+

# Test Use-Cases

1. Enter an invalid directory and click either of the two buttons - note the popup error box
2. Enter the directory of the BUILD_OUTPUT folder and click Version the Build
3. Note how the version numbers in the .dllTracker file have been updated
4. Play around with the versions in the .dllTracker file and see when it gets updated and when it doesnt get updated and how the list of potentially outdated libraries updates
5. Enter the project build names My.First.Project.dll, ..., My.Fifth.Project.dll in the list project names box
6. Click "Check for Outdated Libraries" and note how the .dll files with invalid version updates are included in the textbox
	 
# Specifications not included as per the brief

1. I could have used more sophisticated widgets like WPF text lists instead of single text boxes, but chunky text boxes make input a bit quicker and "flexible". Could have also added graphs showing versions but this wasnt specified
2. I didnt take into account "use the average values in the version sequence to determine which libraries are not up to date" as I was unsure what this exactly meant
3. Assignment didnt specify exactly what UX should be seen on the front-end so I made it in such a way that is as simple to use as possible

# Project next steps and improvement backlogs

1. Make a console version of the DLL Tracker for speed of use
2. Make the DLL Tracker run as a "service" which "listens" to the directory, automatically tracking it, instead of clicking "Version the Build" each time after a project build