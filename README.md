This project was written in .NET 6.0

#### GIT:

git clone <PROJECT_URL>

git submodule init

git submodule update

#### .Net Project: 

In the folder "nutcache-challenge-LeopoldoReginato":
	Execute the query "SQLQuery-Nutcache"

In the "nutcache-challenge-LeopoldoReginato-backend" project:
	Click on the solution with the right mouse button
	Select the Clean Solution option
	Then click the right mouse button again
	Select the Build option
	Execute the project

#### Angular Project
To execute angular project:
	Install angular using your command line:
		angular cli npm install - g @angular/cli.
Inside the project you can search a file named as "environment.ts", open and set the endpoint variable to your local url of the api.

Then go to the folder "nutcache-challenge-LeopoldoReginato-frontend" and type:
	npm install
After that, type:
	ng serve --open