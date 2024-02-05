# Forum

By Henry Oberholtzer & Gabriel Tucker

## Technologies Used

- C#
- MySQL
- EFCore
- Razor Pages

## User Stories

- forum thread topics
  - Topic.cs
    - List of Posts in Topic
    - Topic Title
    - int TopicId
  - User.cs
    - UserId
    - Username
    - List of PostIds

- JoinEntities
    - UserPostJoinEntity.cs
      - UserPostId
      - PostId
      - Post Post
      - UserId
      - User User

# Project Steps
1 - Make it possible to add a 'user' to the database
2 - Make it possible to add a 'topic' to the database
3 - Make it possible to add a 'post' within a 'topic' to the database
4 - Link the 'post' to a 'user'


## Setup/Installation Requirements

- .NET6 or greater is required for set up.
- To establish locally, [download the repository](https://github.com/henry-oberholtzer/digital-hair-salon/archive/refs/heads/main.zip) to your computer.
- Open the folder with your terminal and run `dotnet restore` to gather necessary resources.
- To run the application, within the solution folder, run the command `dotnet run` after the restore.
- A local instance of MySQL is required to be set up and running to use the project.
- You will need to estalish a copy of the database on your own machine, by importing the `henry_oberholtzer.sql` scheme into your server.
- In the production direction, `/ProjectName` run `$ touch appsettings.json`
- In `appsettings.json`, enter the following, replacing `USERNAME` and `PASSWORD` to match the settings of your local MySQL server.
  
```
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database=mvc_forum;uid=USERNAME;pwd=PASSWORD;"
    }
}
```

- To start the projet, in the production directory, run the command `dotnet run`.

## Known Bugs

- Other bugs are left as an exercise to the reader

## License

(c) 2024 [Henry Oberholtzer](https://www.henryoberholtzer.com/) & Gabriel Tucker

Original code licensed under the [GNU GPLv3](https://www.gnu.org/licenses/gpl-3.0.en.html#license), other code bases and libraries as stated.
