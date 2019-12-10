## To make the template usable 
1. Upgrade the packages to the latest version
2. Changes for creating the right docker specification need to be done 
	- in docker-compose.yml 
		- service name: icg.template.webapi
		- image: icgtemplatewebapi
		- dockerfile: ICG.Template.WebApi/Dockerfile
	- in docker-compose.override.yml 
		- service name: icg.template.webapi
	- in Dockerfile 
		- Replace ICG.Template with the API namespace

## How to build the docker image form the project
The docker image can be build in two ways:

### Using docker cli and Dockerfile  
`
    docker build --rm -f Dockerfile -t icg/<packagename>:<version|latest> . 
    docker run -it --rm -p 5000:80 --name <containername> icg/<packagename>:<version|latest>
`

### Using docker-compose
`
docker-compose up -d --build
`