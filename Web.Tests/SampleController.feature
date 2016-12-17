Feature: Nodes
	In order to know where geographically placed my equipment
	As a root user
	I want to be able to create nodes

Scenario: Create node
	Given POST request to api/graph/create-node
	"""
	   { 
	      "Coordinates":"1.23;1.23"
	   }
	"""
	When GET request to api/graph
	Then the response should be
	"""
	   { 
	      "Nodes": [
	             { 
	                "Coordinates":"1.23;1.23"
	             }
	      ]
	   }
	"""
