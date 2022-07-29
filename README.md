# NASA open APIs web site

## Objective
Educational project to get access to NASA APIs and display various types of data (images, charts etc..).
This desktop application is built with .Net - Angular stack, and enables the user to click on some of the APIs available from https://api.nasa.gov/

NB : Other APIs are used as well (for instance the Mars Weather Service API which no longers pushes data, is replaced by the Mars Curiosity API)

## Usage
* Request an API key from https://api.nasa.gov/ 
* Copy and paste the key in the Appsetting.json file.
* Then execute the project.

## APIs implemented
| API | Description | Type | Status |
| --- | ----------- | ---- | ------ |
| https://api.nasa.gov/planetary/apod | Astronomy picture of the day | image | Up and running |
| https://api.nasa.gov/insight_weather | Mars Weather Service API | point data | Not sending data anymore |
| https://mars.nasa.gov/rss/api | Curiosity Rover weather measurement | time series | Implementation |


## Work in progress / future work
* Add more APIs
* Dark mode
