Open i Visual Studio, and publish the project.

Create a Site in IIS that serves the published content.

Note this project is only to test that notifications are working. This IS NOT a production-ready solution.

Path and filename where the SOAP-XML notifications are stored, are defiend in the Web.config in "<configuration><appSettings>..."
NOTE that the windows account used as the IIS ApplicaitonPool Identity must have proper priviliges e.g. if the location requires admin rights etc.

/Heini
