Feature: Simple requests
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Sample request
	Given GET request to api/Sample
	Then the response should be
	"""
	[  
	   { 
	      "Id":1,
	      "Url":"bluh"
	   }
	]
	"""
	