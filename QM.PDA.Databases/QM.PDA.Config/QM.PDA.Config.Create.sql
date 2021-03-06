USE [QM.PDA.Config]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Site](
	[SiteID] [int] NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Code] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Site] PRIMARY KEY CLUSTERED 
(
	[SiteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier of the Site.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Site', @level2type=N'COLUMN',@level2name=N'SiteID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name of the Site.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Site', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code of the Site. This code refers to the 3 digit of the ViCo ID number in the ViCo specific case.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Site', @level2type=N'COLUMN',@level2name=N'Code'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row for each Site where the Study will be conducted.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Site'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DotNETClass](
	[DotNETClassID] [int] NOT NULL,
	[DotNETClassName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_DotNETClass] PRIMARY KEY CLUSTERED 
(
	[DotNETClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for this .NET Class.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DotNETClass', @level2type=N'COLUMN',@level2name=N'DotNETClassID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the .NET class that includes the Function to execute. It should be written in the .NET fully qualified type name.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DotNETClass', @level2type=N'COLUMN',@level2name=N'DotNETClassName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Store one row for each .NET Class with code used in the Study.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DotNETClass'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionnaireSet](
	[QuestionnaireSetID] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Precondition] [nvarchar](100) NULL,
	[SubjectSecondaryIDField] [nvarchar](50) NULL,
	[SubjectAlternativeSearchField] [nvarchar](50) NULL,
	[SubjectConfirmationFields] [nvarchar](200) NULL,
	[NewSubjectSectionID] [int] NULL,
	[OnNewSubjectProcedureID] [int] NULL,
 CONSTRAINT [PK_QuestionnaireSet] PRIMARY KEY CLUSTERED 
(
	[QuestionnaireSetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier of the Questionnaire Set.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'QuestionnaireSetID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The relative order of this Questionnaire Se among all the Questionnaire Sets of the Study.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Short Name for this Questionnaire Set.
ej: H' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Full Name of this Questionnaire Set.
ej: Hospital' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The condition this Questionnaire must fulfill in order to be used.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'Precondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the field of the Subject data table to be used as a secondary study assigned Subject ID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'SubjectSecondaryIDField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the field of the Subject data table to be used as an alternative for those subjects without a study assigned identifier.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'SubjectAlternativeSearchField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores a comma separated list of the fields of the Subject data table that will be used in the Subject selection screen to display confirmation information for the interviewer.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'SubjectConfirmationFields'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The ID of the Section to go when a new Subject is created.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'NewSubjectSectionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the Engine creates a new Subject.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet', @level2type=N'COLUMN',@level2name=N'OnNewSubjectProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Questionnaire Set in the Study.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'QuestionnaireSet'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Study](
	[ShortName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Version] [nvarchar](50) NOT NULL,
	[DesignerVersion] [nvarchar](50) NOT NULL,
	[GeneratorVersion] [nvarchar](50) NOT NULL,
	[CreationDateTime] [datetime] NOT NULL,
	[LastModificationDateTime] [datetime] NOT NULL,
	[GenerationDateTime] [datetime] NOT NULL
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Short Name for the Study
ej: ViCo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Complete Name of the Study
ej: Vigilancia Comunitaria' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The current version of the Study.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'Version'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The version of the Designer used to build this Questionnaire Mobile Design.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'DesignerVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The version of the Generator used to generate this Questionnaire Mobile Configuration File.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'GeneratorVersion'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time the design of the Study was created.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'CreationDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time the design of the Study was last modified.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'LastModificationDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The date and time this file was generated.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study', @level2type=N'COLUMN',@level2name=N'GenerationDateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row with information about the Study.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Study'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Variable](
	[VariableName] [nvarchar](100) NOT NULL,
	[DataType] [nvarchar](50) NOT NULL,
	[MainText] [nvarchar](500) NULL,
	[HelpText] [nvarchar](500) NULL,
	[Required] [bit] NULL,
	[AbsMin] [nvarchar](200) NULL,
	[AbsMax] [nvarchar](200) NULL,
	[PromptUnder] [nvarchar](200) NULL,
	[PromptOver] [nvarchar](200) NULL,
	[LegalValueTable] [nvarchar](100) NULL,
 CONSTRAINT [PK_Variable] PRIMARY KEY CLUSTERED 
(
	[VariableName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Variable which is also its unique identifier.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'VariableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The SQL data type to use with the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Main Text of the Variable. Usually it''s the Question Text.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'MainText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Help Text of the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'HelpText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the user must provide an input value for the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'Required'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the minimum possible value for the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'AbsMin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the maximum possible value for the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'AbsMax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the minimum value for the Variable before a user confirmation is needed. Any input value under this limit needs confirmation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'PromptUnder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the maximum value for the Variable before a user confirmation is needed. Any input value over this limit needs confirmation.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'PromptOver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The table to look for the posible values for this Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable', @level2type=N'COLUMN',@level2name=N'LegalValueTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row for each Variable used in all the Screens.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Variable'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ScreenTemplate](
	[ScreenTemplateID] [int] NOT NULL,
	[DotNETClassName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_ScreenTemplate] PRIMARY KEY CLUSTERED 
(
	[ScreenTemplateID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for the Screen Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenTemplate', @level2type=N'COLUMN',@level2name=N'ScreenTemplateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the .NET class that implements this Template. It should be written in the .NET fully qualified type name.
ej: Namespace.ClassName, AssemblyName' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenTemplate', @level2type=N'COLUMN',@level2name=N'DotNETClassName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Screen Template used by all the Screens.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ScreenTemplate'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Method](
	[MethodName] [nvarchar](450) NOT NULL,
	[DotNETClassID] [int] NOT NULL,
	[DotNETMethodName] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Method] PRIMARY KEY CLUSTERED 
(
	[MethodName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Method which is also its unique identifier.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Method', @level2type=N'COLUMN',@level2name=N'MethodName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for the .NET Class that contains the Method.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Method', @level2type=N'COLUMN',@level2name=N'DotNETClassID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The name of the .NET Method defined inside the .NET Class.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Method', @level2type=N'COLUMN',@level2name=N'DotNETMethodName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each registered Method that can be executed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Method'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcedureStep](
	[ProcedureID] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[MethodName] [nvarchar](450) NOT NULL,
	[MethodArguments] [nvarchar](500) NULL,
 CONSTRAINT [PK_ProcedureStep] PRIMARY KEY CLUSTERED 
(
	[ProcedureID] ASC,
	[Order] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure which this Step belongs to.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProcedureStep', @level2type=N'COLUMN',@level2name=N'ProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The relative order of execution of this Step among all the Steps in a Procedure.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProcedureStep', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Function this Step will call.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProcedureStep', @level2type=N'COLUMN',@level2name=N'MethodName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Arguments for the Function call of this Step.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProcedureStep', @level2type=N'COLUMN',@level2name=N'MethodArguments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Step of a Procedure to be executed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ProcedureStep'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questionnaire](
	[QuestionnaireID] [int] NOT NULL,
	[QuestionnaireSetID] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[MultipleInstances] [bit] NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PreCondition] [nvarchar](450) NULL,
	[InstanceSAIDField] [nvarchar](50) NULL,
	[InstanceSecondaryIDField] [nvarchar](50) NULL,
	[OnNewRecordProcedureID] [int] NULL,
 CONSTRAINT [PK_Questionnaire] PRIMARY KEY CLUSTERED 
(
	[QuestionnaireID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Questionnaire_QuestionnaireID] ON [dbo].[Questionnaire] 
(
	[QuestionnaireSetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for the Questionnaire.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'QuestionnaireID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Questionnaire Set this Questionnaire belogs to.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'QuestionnaireSetID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The relative order of this Questionnaire among all the Questionnaires of the Questionnaire Set.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if this Questionnaire supports multiple instances.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'MultipleInstances'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Short Name for this Questionnaire.
ej: H3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Full Name of this Questionnaire.
ej: Formulario de casos sospechosos' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The condition this Questionnaire must fulfill in order to be used.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'PreCondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the field of the Questionnaire data table to be used as a Study Assigned Instance ID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'InstanceSAIDField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the field of the Questionnaire data table to be used as a Secondary Instance ID.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'InstanceSecondaryIDField'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the Engine creates a new Questionnaire record.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire', @level2type=N'COLUMN',@level2name=N'OnNewRecordProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Questionnaire used in a Questionnaire Set.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Questionnaire'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Section](
	[SectionID] [int] NOT NULL,
	[QuestionnaireID] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[StartScreenID] [int] NOT NULL,
	[ExitScreenID] [int] NOT NULL,
	[Modifiable] [bit] NOT NULL,
	[ShortName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[PreCondition] [nvarchar](450) NULL,
	[OnNewRecordProcedureID] [int] NULL,
 CONSTRAINT [PK_Section] PRIMARY KEY CLUSTERED 
(
	[SectionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_Section_QuestionnaireID] ON [dbo].[Section] 
(
	[QuestionnaireID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier for the Section.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'SectionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Questionnaire this Section belongs to.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'QuestionnaireID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The relative order of this Section among all the Sections of the Questionnaire.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Screen that will be the starting point for this Section.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'StartScreenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Screen that will be the end point of this Section.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'ExitScreenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the data of this Section can be modified once the Section is completed.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'Modifiable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Short Name of the Section.
ej: A, B, C, M' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Full Name of the Section.
ej: Factores de riesgo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The condition this Section must fulfill in order to be used.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'PreCondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the Engine creates a new Section record.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section', @level2type=N'COLUMN',@level2name=N'OnNewRecordProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Section used in a Questionnaire.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Section'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transition](
	[ScreenID] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[DestinationScreenID] [int] NOT NULL,
	[OnTransitionProcedureID] [int] NULL,
	[Condition] [nvarchar](450) NULL,
 CONSTRAINT [PK_Transition] PRIMARY KEY CLUSTERED 
(
	[ScreenID] ASC,
	[Order] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Screen this transition belongs to. The start point of this Transition.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition', @level2type=N'COLUMN',@level2name=N'ScreenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The relative order in which the Condition of this Transition should be evaluated among all the available Transitions for a Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition', @level2type=N'COLUMN',@level2name=N'Order'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Screen to move to. The end point of this Transition.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition', @level2type=N'COLUMN',@level2name=N'DestinationScreenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute if the transition is done.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition', @level2type=N'COLUMN',@level2name=N'OnTransitionProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Condition that must be fulfilled in order to make the transition from the source Screen to the destination Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition', @level2type=N'COLUMN',@level2name=N'Condition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per each Transition used in every Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Transition'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Screen](
	[ScreenID] [int] NOT NULL,
	[SectionID] [int] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](50) NULL,
	[ScreenTemplateID] [int] NULL,
	[Arguments] [nvarchar](500) NULL,
	[VariableScope] [int] NULL,
	[VariableName] [nvarchar](100) NULL,
	[DataType] [nvarchar](50) NULL,
	[MainText] [nvarchar](500) NULL,
	[MainTextColor] [nvarchar](50) NULL,
	[OtherText1] [nvarchar](500) NULL,
	[OtherText1Color] [nvarchar](50) NULL,
	[OtherText2] [nvarchar](500) NULL,
	[OtherText2Color] [nvarchar](50) NULL,
	[OtherText3] [nvarchar](500) NULL,
	[OtherText3Color] [nvarchar](50) NULL,
	[HelpText] [nvarchar](500) NULL,
	[Required] [bit] NULL,
	[AbsMin] [nvarchar](200) NULL,
	[AbsMax] [nvarchar](200) NULL,
	[PromptUnder] [nvarchar](200) NULL,
	[PromptOver] [nvarchar](200) NULL,
	[LegalValueTable] [nvarchar](100) NULL,
	[ExternalValidation] [nvarchar](450) NULL,
	[OnChangeProcedureID] [int] NULL,
	[OnLoadProcedureID] [int] NULL,
	[OnUnloadProcedureID] [int] NULL,
	[ConfirmChange] [bit] NULL,
	[HideNext] [bit] NULL,
	[HideBack] [bit] NULL,
	[ConfirmNext] [bit] NULL,
	[ConfirmBack] [bit] NULL,
 CONSTRAINT [PK_Screen] PRIMARY KEY CLUSTERED 
(
	[ScreenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Unique identifier of this Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ScreenID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Section this Screen belongs to.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'SectionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The full name of this Screen. The value should be <VariableName> if it is not null, otherwise it should be <QuestionnaireShortName><SectionShortName><ScreenType> ej: FNacimiento, H3ABSplash' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Type of this Screen.
ej: Splash, NOP, Info, Question, Exit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Number of the screen in the Designer Tree view.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'Number'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the ScreenTemplate this Screen will use.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ScreenTemplateID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The arguments for the Screen Template in the following form: key1=value1;key2=value2;key3=value3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'Arguments'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the scope of the Variable (Subject, Questionnaire, Section).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'VariableScope'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Name of the Variable that will be handled by this Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'VariableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The SQL data type to use with the Variable. Overrides the DataType field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'DataType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Main Text of the Screen. Its use depends on the Template. Overrides the MainText field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'MainText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Color for the Main Text of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'MainTextColor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Other Text 1 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Color for the Other Text 1 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText1Color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Other Text 2 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Color for the Other Text 2 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText2Color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Other Text 3 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Color for the Other Text 3 of the Screen. Its use depends on the Template.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OtherText3Color'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The Help Text of the Screen. Its use depends on the Template. Overrides the HelpText field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'HelpText'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the user must provide an input value for the Variable. Overrides the Required field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'Required'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the minimum possible value for the Variable. Overrides the AbsMin field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'AbsMin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the maximum possible value for the Variable. Overrides the AbsMax field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'AbsMax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the minimum value for the Variable before a user confirmation is needed. Any input value under this limit needs confirmation. Overrides the PromptUnder field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'PromptUnder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates the maximum value for the Variable before a user confirmation is needed. Any input value over this limit needs confirmation. Overrides the PromptOver field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'PromptOver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The table to look for the posible values for this Variable. Overrides the LegalValueTable field of the Variable table.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'LegalValueTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The extended condition to run for the validation of the user input.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ExternalValidation'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the user sets for the first time or changes the value of the Variable.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OnChangeProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the Engine loads the Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OnLoadProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The unique identifier of the Procedure to execute when the Engine unloads the Screen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'OnUnloadProcedureID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if a user confirmation is needed when the value of the Variable changes.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ConfirmChange'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the Next button should be hidden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'HideNext'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if the Back button should be hidden.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'HideBack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if a user confirmation is needed when clicking the Next button.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ConfirmNext'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Indicates if a user confirmation is needed when clicking the Back button.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen', @level2type=N'COLUMN',@level2name=N'ConfirmBack'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stores one row per Screen to be used in a Section.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Screen'
GO
ALTER TABLE [dbo].[Method]  WITH CHECK ADD  CONSTRAINT [FK_Method_DotNETClass] FOREIGN KEY([DotNETClassID])
REFERENCES [dbo].[DotNETClass] ([DotNETClassID])
GO
ALTER TABLE [dbo].[Method] CHECK CONSTRAINT [FK_Method_DotNETClass]
GO
ALTER TABLE [dbo].[ProcedureStep]  WITH CHECK ADD  CONSTRAINT [FK_ProcedureStep_Method] FOREIGN KEY([MethodName])
REFERENCES [dbo].[Method] ([MethodName])
GO
ALTER TABLE [dbo].[ProcedureStep] CHECK CONSTRAINT [FK_ProcedureStep_Method]
GO
ALTER TABLE [dbo].[Questionnaire]  WITH CHECK ADD  CONSTRAINT [FK_Questionnaire_QuestionnaireSet] FOREIGN KEY([QuestionnaireSetID])
REFERENCES [dbo].[QuestionnaireSet] ([QuestionnaireSetID])
GO
ALTER TABLE [dbo].[Questionnaire] CHECK CONSTRAINT [FK_Questionnaire_QuestionnaireSet]
GO
ALTER TABLE [dbo].[Screen]  WITH CHECK ADD  CONSTRAINT [FK_Screen_ScreenTemplate] FOREIGN KEY([ScreenTemplateID])
REFERENCES [dbo].[ScreenTemplate] ([ScreenTemplateID])
GO
ALTER TABLE [dbo].[Screen] CHECK CONSTRAINT [FK_Screen_ScreenTemplate]
GO
ALTER TABLE [dbo].[Screen]  WITH CHECK ADD  CONSTRAINT [FK_Screen_Variable] FOREIGN KEY([VariableName])
REFERENCES [dbo].[Variable] ([VariableName])
GO
ALTER TABLE [dbo].[Screen] CHECK CONSTRAINT [FK_Screen_Variable]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Questionnaire] FOREIGN KEY([QuestionnaireID])
REFERENCES [dbo].[Questionnaire] ([QuestionnaireID])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Questionnaire]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Screen_ExitScreenID] FOREIGN KEY([ExitScreenID])
REFERENCES [dbo].[Screen] ([ScreenID])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Screen_ExitScreenID]
GO
ALTER TABLE [dbo].[Section]  WITH CHECK ADD  CONSTRAINT [FK_Section_Screen_StartScreenID] FOREIGN KEY([StartScreenID])
REFERENCES [dbo].[Screen] ([ScreenID])
GO
ALTER TABLE [dbo].[Section] CHECK CONSTRAINT [FK_Section_Screen_StartScreenID]
GO
ALTER TABLE [dbo].[Transition]  WITH CHECK ADD  CONSTRAINT [FK_Transition_DestinationScreen] FOREIGN KEY([DestinationScreenID])
REFERENCES [dbo].[Screen] ([ScreenID])
GO
ALTER TABLE [dbo].[Transition] CHECK CONSTRAINT [FK_Transition_DestinationScreen]
GO
ALTER TABLE [dbo].[Transition]  WITH CHECK ADD  CONSTRAINT [FK_Transition_Screen] FOREIGN KEY([ScreenID])
REFERENCES [dbo].[Screen] ([ScreenID])
GO
ALTER TABLE [dbo].[Transition] CHECK CONSTRAINT [FK_Transition_Screen]
GO
