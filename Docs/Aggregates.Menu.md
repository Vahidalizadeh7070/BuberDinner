## Domain Model
## Menu

```json
{
    "id" : "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e",
    "name" : "test",
    "description" : "test",
    "section" : [
        {
            "id" : "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e",
            "name" : "test",
            "description" : "test",
            "items" : [
                {
                    "id" : "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e",
                    "name" : "test",
                    "description" : "test",
                    "price" : 1200
                }
            ] 
        }
    ],
    "hostId" : {"value": "20fca7a6-1481-452c-8f6e-3fb5a6cbb13e"},
    "createdDateTime" : "2022-04-05",
    "updatedDateTime" : "2022-04-05",
    "dinnerIds" : ["20fca7a6-1481-452c-8f6e-3fb5a6cbb13e"],
    "menuReviewIds" : ["20fca7a6-1481-452c-8f6e-3fb5a6cbb13e"] 
}
```
```chsarp
class Menu
{
    Menue Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner);
    void UpdateSection(MenuSection menuSection);
}
```