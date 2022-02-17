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

select * from TournamentsPrizes;

create table Tournaments
(
	id int not null identity,
	TournamentsName varchar(100) not null,
	EntryFees int not null,
	Primary key(id)
);

Alter Procedure dbo.spInsert_Tournaments
	@TournamentsName varchar(100),
	@EntryFees int ,
	@id int = 0 output
as
begin
	insert into dbo.Tournaments(TournamentsName,EntryFees)
	values(@TournamentsName,@EntryFees)
	select @id=SCOPE_IDENTITY();
end
go


create table DistributePrizes
(
	id int not null identity,
	TournamentsId int not null,
	PrizeId int not null,
	primary key(id),
	foreign key(TournamentsId) REFERENCES Tournaments(id),
    foreign key(PrizeId) REFERENCES TournamentsPrizes(id)


);

create Procedure dbo.spDistributePrizes_Insert
	@TournamentsId int,
	@PrizeId int,
	@id int = 0 output
as
begin
	insert into dbo.DistributePrizes(TournamentsId,PrizeId)
	values(@TournamentsId,@PrizeId);

	select @id= SCOPE_IDENTITY();
end
go




create table Teams
(
	id int not null identity ,
	TeamName varchar(100) not null,
	primary key(id)
);

create Procedure dbo.spGetTeam_All
as
begin
	select * from 
	dbo.Teams
end 
go

create Procedure dbo.spTeams_Insert
	@TeamName varchar(100),
	@id int = 0 output
as
begin
	insert into Teams(TeamName)
	values(@TeamName)

	select @id=SCOPE_IDENTITY();
end
go
	

create table TournamentsEntries
(
	id int not null identity,
	TournamentsId int not null,
	TeamId int not null,
	primary key(id),
    foreign key(TournamentsId) REFERENCES Tournaments(id),
	foreign key(TeamId) REFERENCES Teams(id),



);

create Procedure dbo.spTournamentsEntries_Insert
	@TournamentsId int,
	@TeamId int,
	@id int = 0 output
as
begin
	insert into TournamentsEntries(TournamentsId,TeamId)
	values(@TournamentsId,@TeamId);

	select @id=SCOPE_IDENTITY();
end
go

create table Player
(
	id int not null identity,
	FirstName varchar(100) not null,
	LastName varchar(100) not null,
	EmailAddress varchar(300) not null,
	CellPhonenumber bigint not null,
	Primary key(id)
);

create Procedure dbo.spGetPlayer_All
as
begin
	select * from Player
end 
go

exec dbo.spGetPlayer_All;

create Procedure dbo.spInsertPlayer
	@FirstName varchar(100),
	@LastName varchar(100),
	@EmailAddress varchar(300),
	@CellPhonenumber bigint,
	@id int = 0 output
as
begin
	insert into dbo.Player(FirstName,LastName,EmailAddress,CellPhonenumber)
	values
	(
		@FirstName,
		@LastName,
		@EmailAddress,
		@CellPhonenumber
	);

	select @id=SCOPE_IDENTITY();
end
go


create table TeamMembers 
(
	id int not null identity,
	TeamId int not null,
	PlayerId int not null,
	primary key(id),
    foreign key(TeamId) REFERENCES Teams(id),
	foreign key(PlayerId) REFERENCES Player(id)

	
);

create Procedure dbo.spTeamMembers_Insert
	@TeamId int,
	@PlayerId int,
	@id int = 0 output
as
begin
	insert into TeamMembers(TeamId,PlayerId)
	values(@TeamId,@PlayerId)

	select @id=SCOPE_IDENTITY();
end
go

create table MatchUps
(
	id int not null identity,
	winnerId int not null,
	MatchUpRounds int not null,
	Primary key(id),
	foreign key(winnerId) REFERENCES Teams(id),


);

alter table dbo.MatchUps

 add  TournamentId int,
 foreign key(TournamentId) REFERENCES Tournaments(id)

create Procedure dbo.spInsert_Matchups
	@MatchUpRounds int,
	@TournamentId int,
	@id int=0 output
as
begin
 insert into dbo.MatchUps(MatchUpRounds,TournamentId)
 values(@MatchUpRounds,@TournamentId)
 select @id=SCOPE_IDENTITY();
end
go


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

create Procedure dbo.spMatchupsEntries_Insert
	@Matchupid int,
	@ParentMatchupid int,
	@Teamcompetingid int,
	@id int = 0 output
as
begin
	insert into dbo.MatchupEntries(Matchupid,ParentMatchupid,Teamcompetingid)
	values(@Matchupid,@ParentMatchupid,@Teamcompetingid)

	select @id=SCOPE_IDENTITY();
end
go


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

create Procedure dbo.spInsertTournamentPrize
	@Placenumber int,
	@PlaceName Varchar(50),
	@PrizeAmount money,
	@PrizePercentage float,
	@id int=0 output
as 
begin
	insert into dbo.TournamentsPrizes(Placenumber,PlaceName,PrizeAmount,PrizePercentage)
	values(
		@Placenumber,
		@PlaceName,
		@PrizeAmount,
		@PrizePercentage
	);

	--SCOPE_IDENTITY() 
	--returns the IDENTITY value inserted in Table
	-- This was the last insert that occurred in the same scope.
	-- The SCOPE_IDENTITY() function returns the null value if the function is invoked 
	-- before any INSERT statements into an identity column occur in the scope.
	select @id=SCOPE_IDENTITY();
End
go

create Procedure dbo.spTeamMembers_GetByTeams
	@Teamid int
as
begin
	set nocount on;

	select p.*
	from dbo.TeamMembers m
	inner join dbo.Player p on m.PlayerId=p.id
	where m.TeamId=@Teamid;
end 
go




