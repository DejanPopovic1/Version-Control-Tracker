#Setting up, running and testing the Project
*) Install the latest version of Visual Studio
*) Open the projects solution (.sln) folder
*) The DLL files are contained in a folder loacted in the project root directory called "myDLLs"

#Assumptions and Features that have not been implemented because they werent specified
*) The two data tables each have a unique key generated by MS SQL
*) Info table has a foreign key and primary key.
   - The foreign key does not equal the primary key
   - One could argue they should be the same because its a one to one relationship but its actually not one to one
   - Two different people could have the same Info table values
   - e.g. Its possible to have the same persons living address and same number in the instance of a spouse using next of kin details
*) Validations could have been stricter, but validations werent specified in the take home test
*) Going to the Info page forces the user to change password which in the real world shouldnt be the case. It wasnt specified to avoid this scenario so I left it
*) The "without using post-back" is a bit ambiguous especially in the context of AJAX, Web Services, etc - I therefore implemented it how I interpreted it
*) Security:
   - Basic security features like Sql string parameterisation are used instead of string concatenation to prevent SQLInjection attacks
   - There could be some security vulnerabilities but it wasnt specified to firm up security loopholes
     
#Flaws/Things done differently
*) When adding more entries to the DB over and above the user "Mary", the Info page always reverts to the last entry of the DB which is an error
   - This is because there is an error in the getMainPageModel() function in the HomeController. Its actually easy to fix but no time to do so
*) I used an email as an ID for person
*) Entering a blank password in the Info page causes crash upon submission - no time to add validation
*) A field called LastLogin in Person table should exist. For some reason I couldnt get the date class working so I left it out