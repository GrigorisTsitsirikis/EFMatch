CREATE TABLE [dbo].[Match] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    [MatchDate]   DATETIME2 (7)  NULL,
    [MatchTime]   NVARCHAR (50)  NOT NULL,
    [TeamA]       NVARCHAR (100) NOT NULL,
    [TeamB]       NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Match] PRIMARY KEY CLUSTERED ([ID] ASC)
);


CREATE TABLE [dbo].[MatchOdds] (
    [ID]        INT          IDENTITY (1, 1) NOT NULL,
    [MatchId]   INT          NOT NULL,
    [Specifier] NVARCHAR (1) NOT NULL,
    [Odd]       REAL         NOT NULL,
    CONSTRAINT [PK_MatchOdds] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MatchOdds_Match_MatchId] FOREIGN KEY ([MatchId]) REFERENCES [dbo].[Match] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_MatchOdds_MatchId]
    ON [dbo].[MatchOdds]([MatchId] ASC);

