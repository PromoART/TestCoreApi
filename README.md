# TestCoreApi
.Core service for testing functionality of Autofac and NHibernate

Update/Delete function isn't tested

To create player
{
  "Id": null,
  "FullName": "Ron Harper",         -require field
  "Position": "PointGuard",         -require field
  "Age": "29",                      -require field
  "ClubId": null,
  "Club":   {
                "id": null,
                "Name": "Chicago Bulls", - specify team name if this team exist in database
                "Town": null,
                "Players": null
            }
}


To create club 
{
  "Id": null,
  "Name": "Chicago Bulls",          -require field
  "Town": "Chicago",                -require field
  "Players": null 
}
