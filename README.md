# Integration with google maps

To launch the project you have to:

1. Create your own GoogleAPI key and put it in appsettings.json
2. Fill ConnectionStrings with your DB parameters
3. Launch the project and paste json body in request. Example:
```
{
    "entityID":"edcd441e-83e7-4653-b0e9-111111111111",
    "placeID":"ChIJV5oQCXzdOkcR4ngjARfFI0I",
    "locationParts":
    {
        "79000":["postal_code"],
        "Львів":["locality","political"],
        "Львівська міськрада":["administrative_area_level_3","political"],
        "Львівська область":["administrative_area_level_1","political"],
        "Україна":["country","political"]
    }
}
```
Where

```entityID``` - identifier of existing entity which you want to bind to the location

```placeID``` - ID of place (https://developers.google.com/maps/documentation/places/web-service/place-id)

```locationParts``` - additional parts of the main place (https://developers.google.com/maps/documentation/places/web-service/supported_types#table2)
