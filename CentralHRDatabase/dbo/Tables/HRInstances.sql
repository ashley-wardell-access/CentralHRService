CREATE TABLE [dbo].[HRInstances] (
    [InstanceId]     INT              IDENTITY (1, 1) NOT NULL,
    [InstanceName]   VARCHAR (255)    NOT NULL,
    [LicenseGuid]    UNIQUEIDENTIFIER NOT NULL,
    [LastRunSSUGuid] UNIQUEIDENTIFIER NOT NULL,
    [VersionMajor]   INT              NOT NULL,
    [VersionMinor]   INT              NOT NULL,
    [Build]          INT              NOT NULL,
    [Revision]       INT              NOT NULL,
    [LastPing]       DATETIME         NOT NULL
);

