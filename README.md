# iThesaurus

This is a simple app to add and retrieve Synonyms.
It is built using Asp.net WebApi, EF6 and AngularJS. It also uses multi-tier DDD architecture, Unity IoC, Twitter Bootstrap, HTML5 and Unit Tests.

The solution uses Visual Studio 'LocalDB' however, the configuration may be changed to any desired database service of choice, in the config file.
The application uses EF Code First and will hence, populate the database automatically on the first run.

Future actions/enhancements to the project include:
- caching mechanism
- paging (client + server)
- external API integration for fetching new words
- would like to use an integer field for PK instead of WordText
- micro/verbose exception logging using a readymade logging library
- going async all the way
- cloud services

Here are a few snapshots from the application:

## Home Page ##
![1.JPG](https://github.com/vaibhavsingh007/iThesaurus/blob/origin/1.PNG?raw=true)

## Searching a Synonym (recursive lookup) ##
![2.JPG](https://github.com/vaibhavsingh007/iThesaurus/blob/origin/2.PNG?raw=true)

## Adding a Synonym ##
![3.JPG](https://github.com/vaibhavsingh007/iThesaurus/blob/origin/3.PNG?raw=true)

## Synonym added ##
![4.JPG](https://github.com/vaibhavsingh007/iThesaurus/blob/origin/4.PNG?raw=true)
