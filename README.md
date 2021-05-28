# Setting up the project

*) Install the latest version of Visual Studio
*) Open the projects solution (.sln) folder
*) For the purposes of testing, a folder called BUILD_OUTPUT is included which contains 10 DLL's with the following information:
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
*) For the purposes of testing, you may treate the pattern My.*.Project.dll as a project build, and everything else as either a non dll file or a dll third party file. Note that these project builds have the following version numbers:
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

*) Build and run the application
*) Enter the directory in which the version control tracking must occur
   For testing purposes, specify the directory to include the BUILD_OUTPUT folder supplied with this project
   Note that the path must be absolute and not relative, e.g.:
   C:\MyFile\MyOtherFile\BUILD_OUTPUT
*) This application is used, and works, in the following way:
    - After every project build, the output of those builds must be made into the BUILD_OUTPUT folder
	- The DLL tracker app must then be opened and the button "Version the Build" must be clicked
	- This adds the version contents of the BUILD_OUTPUT to a CSV file called .dllTracker
	- The .dllTracker file keeps track of the versions of the dll's in the file
	- Therefore, a build cycle would consist of the following cycle:
	  build project -> Open DLLTracker and click Version the Build -> build project -> Open DLLTracker and click Version the Build -> etc...
	  By following this cycle, .dllTracker CSV file "grows" with the number of version sequences
*) What's a valid version update anyway?
    - The test dll's included with the submission follow the De Facto assembly versioning standard, namely, <major version>.<minor version>.<build number>.<revision>
	- A valid project build update would include any change in version number such that the *overall* version number increases. To demonstrate this, consider the following examples:
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
	   +---------------|---------------------+---------------+
*) Catering for third party libraries
   - All project build outputs must be specified in the textbox under "List project names"
   - These names must be seperated by a newline and nothing else
   - Duplicates have no altering effect
   - Any file not included in this textbox is taken to be a third party library and will not be displayed as having potentially outdated libraries
*) To check for outdated libraries, click the "Check for Outdated Libraries" button; This will ensure that the DLL's with an invalid version number update will be shown
*) An analogy to the DLLTracker app may be found with the Git version control system with the following analogies:
	   +---------------+----------------------------------------------------+
	   |Git            |DLL Tracker                                         |
	   +---------------+----------------------------------------------------+
	   |.git folder    |.dllTracker folder                                  |
	   +---------------+----------------------------------------------------+
	   |git commit     |Version the Build                                   |
	   +---------------|----------------------------------------------------+
	   |git ignore     |Any file not included in the List Project Names box |
	   +---------------+----------------------------------------------------+

# Test Use-Cases

*) Enter an invalid directory - note the popup error box
*) Enter the directory of the BUILD_OUTPUT folder and click Version the Build
*) Note how the version numbers in the .dllTracker file have been updated
*) Enter the project build names My.First.Project.dll, ..., My.Fifth.Project.dll in the list project names box
*) Click "Check for Outdated Libraries" and note how the .dll files with invalid version updates are included in the textbox
	 
# Specifications not included as per the brief

*) I could have used more sophisticated widgets like WPF text lists instead of single text boxes, but chunky text boxes make input a bit quicker and "flexible"
*) I didnt take into account "use the average values in the version sequence to determine which libraries are not up to date" as I was unsure what this exactly meant

# Project next steps and improvement backlogs

*) Make a console version of the DLL Tracker for speed of use
*) Make the DLL Tracker run as a "service" which "listens" to the directory, automatically tracking it, instead of clicking "Version the Build" each time after a project build