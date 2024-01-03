Feature: Demo

Background: 
	Given Set The API URL AS 'https://reqres.in'

Scenario Outline: Get List Users
	Given Set The API End Point As 'api/users'
	And Set the Parameter Key and Value
		| QueryParameterName  | QueryParameterValue |
		| page				  | 2			        |
	When Send a GET request
	Then The response status code should be expected Status Code	
		| expectedStatusCode  |
		| 200                 |

Scenario Outline: Get Single User
	Given Set The API End Point As 'api/users'
	And Set the user id
		| id   |
		| <id> |
	When Send a GET request
	Then The response status code should be expected Status Code	
		| expectedStatusCode	|
		| <expectedStatusCode>  |
	Examples: 
	| id | expectedStatusCode |
	| 2  | 200                |
	| 23 | 404                |

Scenario Outline: List Resorce
	Given Set The API End Point As 'api/unknown'
	When Send a GET request
	Then The response status code should be expected Status Code	
		| expectedStatusCode  |
		| 200                 |

Scenario Outline: Single Resorce
	Given Set The API End Point As 'api/unknown'
	And Set the user id
		| id   |
		| <id> |
	When Send a GET request
	Then The response status code should be expected Status Code	
		| expectedStatusCode   |
		| <expectedStatusCode> |
	Examples: 
	| id | expectedStatusCode |
	| 2  | 200                |
	| 23 | 404                |

Scenario Outline: Post Create Users
	Given Set The API End Point As 'api/users'
	And the request body is:
		"""
        {
            "name": "John Doe",
            "email": "john.doe@example.com"
        }
        """
	When Send a Post request
	Then The response status code should be expected Status Code	
		| expectedStatusCode  |
		| 201                 |
