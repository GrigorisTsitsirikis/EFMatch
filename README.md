The solution has 2 projects :   

**EFDataLibrary** : A .net standard 2.1 that has all the data Access Layers. The migrations, the models, and the dbContext. It is compatible with both .net Core and .net6. It has been created for organization purposes and simplicity.  

**EFMatch** : A .net Core 3.1 web api project that has all the API functionality.


**EFMatch Project**
The project when it's first created it creates the matchDB database locally if it doesn't already exist in the connection string specified in the appSettings along with the initial EF Model. There are some migration scripts that change the model a bit with Add-migration {name} and Update-Database commands so it is finalized. The initial produced script and the final after the migrations, have been uploaded in the EFDataLibrary Project. Finally there are some initialData that are loaded if the db data are empty for Matches and MatchOdds that can also get deleted by the functionallity of the project.
There is also Swagger and Postman Collection in the project.

The project has 2 controllers:  

**MatchesController**

This controller has 5 endpoints for CRUD operations in table Match:
* /api/Matches  (GET)
* /api/Matches/{{matchId}} (GET)
* /api/Matches (POST)
* /api/Matches/{{matchId}} (PUT)
* /api/Matches/{{matchId2}} (DELETE)

This controller has 5 endpoints for CRUD operations in table MatchOdds:  

**MatchOddsController**
* /api/MatchOdds/{{matchOddsId}} (GET)
* /api/MatchOdds (GET)
* /api/MatchOdds (POST)
* /api/MatchOdds (PUT)
* /api/MatchOdds (DELETE)

# MatchController

# 1. GetMatches
```
public async Task<ActionResult<IEnumerable<Match>>> GetMatches()
```  

**Description**
Returns All matches that are stored in Match table.

**URL** : `/api/Matches/`  

**Method** : `GET`
## Success Response
**Code** : `200 OK`  

**Content examples**

For the initial 3 games added.
```json
{
        "id": 2048,
        "description": "OSFP-PAO",
        "matchDate": "2021-05-19T00:00:00",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "PAO",
        "sport": 1
    },
    {
        "id": 2049,
        "description": "OSFP-AEK",
        "matchDate": "2021-05-19T00:00:00",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "AEK",
        "sport": 1
    },
     {
        "id": 2050,
        "description": "OSFP-AEK",
        "matchDate": "2021-05-19T00:00:00",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "AEK",
        "sport": 2
    }
```
When all games have been deleted. It returns an empty List.
```json
{
[]
}
```
## Notes
3 Games are intially created by the app for testing purposes.

# 2. GetMatch
```
 public async Task<ActionResult<Match>> GetMatch(int id)
```
**Description**
Returns a specific match based on the match id in the url.

**URL** : `/api/Matches/{id}`  

**Method** : `GET`  

## Success Response
**Code** : `200 OK`  

**Content examples**

For **URL** : `/api/Matches/2048`
```json
{
        "id": 2048,
        "description": "OSFP-PAO",
        "matchDate": "2021-05-19T00:00:00",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "PAO",
        "sport": 1
    }
```
When all games have been deleted.
## Fail Response  

**Code** : `404 Not Found`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|e0a9c2de-439662367ef028c0."
}
```
# 3. PostMatch
```
 public async Task<ActionResult<Match>> PostMatch(Match Match)
```
Creates a new Match
**URL** : `/api/Matches`  

**Method** : `POST`  

## Request
**Code** : `200 OK`  

**Content examples**

For **URL** : `/api/Matches`
```json
{
        "description": "OSFP-PAO",
        "matchDate": "2012-04-23",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "PAO",
        "sport":1
    }
```
## Success Response  

**Code** : `201 Created`
```json
{
    "id": 2051,
    "description": "OSFP-PAO",
    "matchDate": "2022-04-23T00:00:00",
    "matchTime": "12:00",
    "teamA": "OSFP",
    "teamB": "PAO",
    "sport": 1
}
```
## Fail Response
If the same game (description,teamA,teamB,sport and matchDate) is posted **again** validation has been added and an exception is thrown.  

**Code** : `500 Internal Server Error`
```json
System.Data.DataException: This match already exists. Please alter it with Put method
```

# 4. PutMatch
```
 public async Task<IActionResult> PutMatch(int id, Match match)
```
Updates the data of an existing match
**URL** : `/api/Matches/{id}`  

**Method** : `PUT`  

## Request
**Code** : `200 OK`  

**Content examples**

For **URL** : `/api/Matches/2048`
```json
  {
         "id":2048,
        "description": "OSFP-PAOK",
        "matchDate": "2021-05-19",
        "matchTime": "12:00",
        "teamA": "OSFP",
        "teamB": "PAOK",
        "sport":1
    }
```
## Success Response
**Code** : `204 No content`
```json
{
}
```
## Fail Response
If the url has different id from the body of the request.
e.g For URL : /api/Matches/2048
id:2049 in the body
We have a fail Response.

**Code** : `400 Bad Request`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "Bad Request",
    "status": 400,
    "traceId": "|e0a9c2e4-439662367ef028c0."
}
```
# 4. DeleteMatch
```
public async Task<IActionResult> DeleteMatch(int id)
```
Updates the data of an existing match
**URL** : `/api/Matches/{id}`  

**Method** : `DELETE`  

**Code** : `204 No content`

For **URL** : `/api/Matches/2049`
## Success Response
**Code** : `204 No content`
```json
{
}
```
## Fail Response
If the game is not found: 
e.g For URL : /api/Matches/2099
We have a fail Response.
**Code** : `404 Not Found`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|e0a9c2e6-439662367ef028c0."
}
```
## Notes
If the game is deleted all the game Odds with the specific matchId are also deleted because of foreignkey. The 2 tables are connected.

# MatchOddsController
# 1. GetMatchOdds
```
public async Task<ActionResult<IEnumerable<MatchOdds>>> GetMatchOdds()
```
**Description**
Returns All matchOdds that are stored in MatchOdds table.

**URL** : `/api/MatchOdds/`  

**Method** : `GET`  

## Success Response
**Code** : `200 OK`
**Content examples**

For the initial 3 gameOdds added.
```json
{
   
    },
    {

    },
     {

    }
```
When all gameOdds have been deleted. It returns an empty List.
```json
{
[]
}
```
## Notes
3 Game Odds are intially created by the app for testing purposes.

# 2. GetMatchOdds
```
 public async Task<ActionResult<MatchOdds>> GetMatchOdds(int id)
```
**Description**
Returns a specific match based on the matchOdds id in the url.

**URL** : `/api/MatchOdds/{id}`  

**Method** : `GET`  
## Success Response
**Code** : `200 OK`  

**Content examples**

For **URL** : `/api/MatchOdds/2055`
```json
{
      
    }
```
When all games have been deleted.
## Fail Response
**Code** : `404 Not Found`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|e0a9c2de-439662367ef028c0."
}
```
# 3. PostMatchOdds
```
  public async Task<ActionResult<MatchOdds>> PostMatchOdds(MatchOdds MatchOdds)
```
**Description**
Creates a new Match  

**URL** : `/api/MatchOdds`  

**Method** : `POST`  

## Request
**Code** : `200 OK`
**Content examples**

For **URL** : `/api/MatchOdds`
```json
{
        "matchId": 2050,
        "specifier": "1",
        "odd": 1.2
    }
```
## Success Response
**Code** : `201 Created`
```json
{

}
```
## Fail Response
If the same matchOdd (matchId,Specifier) is posted **again** validation has been added and an exception is thrown.
**Code** : `500 Internal Server Error`
```json
System.Data.DataException: Specifier for this match Odds already exists. Please Use Put method to alter it
```

# 4. PutMatchOdds
```
public async Task<IActionResult> PutMatchOdds(int id, MatchOdds matchOdds)
```
Updates the data of an existing match
**URL** : `/api/MatchOdds/{id}` 

**Method** : `PUT`  

## Request
**Code** : `200 OK`
**Content examples**

For **URL** : `/api/MatchOdds/2055`
```json
  {
        "id": 2055,
        "matchId": 2050,
        "specifier": "X",
        "odd": 1.5
    }
```
## Success Response
**Code** : `204 No content`
```json
{
}
```
## Fail Response
If the url has different id from the body of the request.
e.g For URL : /api/MatchOdds/2055  
id:2049 in the body
We have a fail Response.

**Code** : `400 Bad Request`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.1",
    "title": "Bad Request",
    "status": 400,
    "traceId": "|e0a9c2e4-439662367ef028c0."
}
```
# 5. DeleteMatchOdds
```
public async Task<IActionResult> DeleteMatchOdds(int id)
```
Updates the data of an existing match
**URL** : `/api/MatchOdds/{id}`  

**Method** : `DELETE`  

**Code** : `204 No content`

For **URL** : `/api/MatchOdds/2056`
## Success Response
**Code** : `204 No content`
```json
{
}
```
## Fail Response
If the gameOdd is not found: 
e.g For URL : /api/Matches/2099
We have a fail Response.
**Code** : `404 Not Found`
```json
{
    "type": "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    "title": "Not Found",
    "status": 404,
    "traceId": "|e0a9c2e6-439662367ef028c0."
}
```
