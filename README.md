# PuzzleSolver

This is an ASP NET application that solves board puzzles.
It uses a MongoDB as the database for the puzzle that were already been solved. I.E: the same puzzle will not be solved again.

It currenty has only the option to solve the "Sliding Puzzle".

It has two algorithms to solve the puzzle: BFS and DFS.

# Prequires to run this application
- MongoDB installed.
- ASP NET 6.0
- Visual Studio 2022

# How To use
- Configure the "ConnectionString" in the "appsettings.json" file to connecnt to your mongodb instance.
- Complie the solution and do nuget restore if needed.
- Run the program. It is defaulted to "http://localhost:8000"

# Send API Requests
There is only 2 API GET calls you can make:
- http://localhost:8000/api/solve
- http://localhost:8000/api/puzzle/{id}

The body of the request for the "/api/solve" is in a json foramt:

```
{
    "PuzzleType" : "Sliding",
    "PuzzleSolverAlgorithm" : "DFS",
    "InitialBoardState" : [
            [1, 0, 3],
            [4, 2, 5]
        ]
}
```

The response contains the id of the puzzle that was stored in the db for future use, and a list of all the intermidiate steps to get to the solution of the puzzle.
An empty list will return if no solution was found. 
An error will return if the request body is in the wrong format, or contains wrong information, I.E: Unknow puzzle type, solving algorithm or invalid board state.

An example of a curl command to use:
`curl -X GET "http://localhost:8000/api/solve" -d "@example.json" -H "Content-type: application/json"`

Where the file `example.json` have the example above.
