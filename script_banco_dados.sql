USE [dbMedGrupo]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- DROP TABLE [dbo].[contatos];
-- GO
--

CREATE TABLE [dbo].[contatos] (
    [idContato]      INT           IDENTITY (1, 1) NOT NULL,
    [nome]           VARCHAR (250) NOT NULL,
    [dataNascimento] SMALLDATETIME NOT NULL,
    [sexo]           CHAR (1)      NOT NULL
);
GO


