# What will it be?

First, I'll make an MVP which is adaptable for changes using the MVC pattern.
There will be a web application and a desktop application.

#### Web portal

- allow guests to book rooms
- let potential guest know if room is available

#### Desktop app

- the guest will check in via desktop app
- able to look up guest reservation by name or other piece of information




# Things for the MVP

- ASP.NET Razor pages
- There will be only one hotel
- Guests book a hotel room type, not a specific room
### Web page - Searching for a room
	- Start date
	- End date
	- Displays list of hotel room types that are available
	- User can choose one to book
	
### Web page - Book room
	- Takes room from search page
	- Ask for guest info (name)
	- Book upon submission

## WPF Core Desktop App
- A hotel employee will check guests in
### WPF page - Search for user
	- Search by last name and use today's date
	- Display list of matching reservations
	- Have a button that checks in a guest
	
- SQL Server data storage
- No API middle layer


# Things for a future version

- Authenticate guests
- Guest history
- Multiple hotel capabilities
- Allow guests to check out
- Allow booking search by reservation number or other piece of information
- Allow implementation of different GUI
- Allow data to be stored in other database types

