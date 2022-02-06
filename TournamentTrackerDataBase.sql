create database TournamentsTracker;

use TournamentsTracker;

create table TournamentsPrizes
(
	id int not null identity,
	Placenumber int not null,
	PlaceName varchar(50) not null,
	PrizeAmount money not null,
	PrizePercentage decimal,
	primary key (id)
);

create table Tournaments
(
	id int not null identity,
	TournamentsName varchar(100) not null,
	EntryFees int not null,
	Primary key(id)
);

create table DistributePrizes
(
	id int not null identity,
	TournamentsId int not null,
	PrizeId int not null,
	primary key(id),
	foreign key(TournamentsId) REFERENCES Tournaments(id),
    foreign key(PrizeId) REFERENCES TournamentsPrizes(id)


);

create table Teams
(
	id int not null identity ,
	TeamName varchar(100) not null,
	primary key(id)
);

create table TournamentsEntries
(
	id int not null identity,
	TournamentsId int not null,
	TeamId int not null,
	primary key(id),
    foreign key(TournamentsId) REFERENCES Tournaments(id),
	foreign key(TeamId) REFERENCES Teams(id),



);

create table Player
(
	id int not null identity,
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	EmailAddress varchar(300) not null,
	CellPhonenumber bigint not null,
	Primary key(id)
);

create table TeamMembers 
(
	id int not null identity,
	TeamId int not null,
	PlayerId int not null,
	primary key(id),
    foreign key(TeamId) REFERENCES Teams(id),
	foreign key(PlayerId) REFERENCES Player(id)

	
);

create table MatchUps
(
	id int not null identity,
	winnerId int not null,
	MatchUpRounds int not null,
	Primary key(id),
	foreign key(winnerId) REFERENCES Teams(id),


);

create table MatchupEntries
(
	id int not null identity,
	Matchupid int not null,
	ParentMatchupid int not null,
	Teamcompetingid int not null,
	score int not null,
	primary key(id),
	foreign key(Matchupid) REFERENCES MatchUps(id),
	foreign key(ParentMatchupid) REFERENCES MatchUps(id),
	foreign key(Teamcompetingid) REFERENCES Teams(id)
	



);

create Procedure [dbo].[spPrizes_GetbyTournaments]
	@TournamentsId int
As
Begin
	set nocount on;

	select p.*
	from dbo.TournamentsPrizes p
	inner join dbo.DistributePrizes t on p.id=t.PrizeId
	where t.TournamentsId=@TournamentsId;
end

create Procedure [dbo].[SpPlayer_GetByLastName]
	@lastname varchar(100)
as
begin
	set nocount on;

	select * 
	from dbo.Player
	where LastName=@lastname;
end

create Procedure [dbo].[SpTournaments_GetAll]

create Procedure [dbo].[SpMatchupEntries_GetByMatchUp]
	@Matchupid int
as
begin

	set nocount on;

	select *
	from dbo.MatchupEntries 
	inner join dbo.MatchUps on dbo.MatchupEntries.Matchupid=dbo.MatchUps.id
	where dbo.MatchupEntries.Matchupid=@Matchupid;
end

create Procedure [dbo].[SpTournaments_GetAll]
as
begin
	select * from
	dbo.Tournaments;
end

create Procedure [dbo].[SpTeamMember_GetByTeam]
	@Teamid int
as
Begin
	select T.*
	from dbo.TeamMembers T
	inner join dbo.Teams on T.TeamId=dbo.Teams.id
	where T.TeamId=@Teamid;
end