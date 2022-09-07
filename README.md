# BroadwayReview
## ASP.Net University Project for ICT
## _Nikolina Pivalica 9/17_

This project is made as na API appliaction in .NET 5 and it provides reviews for plays on Broadway

## Functionalities
- Registration
- Login
- Search
- Pagination
- Filter
- CRUD on all entities
- Limited access to content
- Sending email (even though it's commented out beacuse of Google policy)

##Description
- Users can login and register, as well as leave a review and rating for a play
- Plays can be searched for by year, title, duration, genre or actos
- Reviews can be searched for by title, text of the review, play the review is about and rating

##Database diagram

##Reproduction steps
- Make a database _BroadwayReview_ in SSMS if not using the script provided
- In DataAccess Project change the connection string to match yours
- Migrate and Update Database
- Ping: GET http://localhost:5000/api/InitialData - this endpoint seeds the database and adds admin user
- Token: ping POST http://localhost:5000/api/auth/token with the JSON object Email: administrator@asp.com, Password: ASPAdmin879&
- Administrator can ping all endpoints now

