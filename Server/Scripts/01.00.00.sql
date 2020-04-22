/*  
Create TresStripe table
*/

CREATE TABLE [dbo].[Stripe](
	[StripeId] [int] IDENTITY(1,1) NOT NULL,
	[ModuleId] [int] NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
	[StripeConnectId] [nvarchar](256) NOT NULL,
	[CreatedBy] [nvarchar](256) NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[ModifiedBy] [nvarchar](256) NOT NULL,
	[ModifiedOn] [datetime] NOT NULL,
  CONSTRAINT [PK_Stripe] PRIMARY KEY CLUSTERED 
  (
	[StripeId] ASC
  )
)
GO

/*  
Create foreign key relationships
*/
ALTER TABLE [dbo].[Stripe]  WITH CHECK ADD  CONSTRAINT [FK_Stripe_Module] FOREIGN KEY([ModuleId])
REFERENCES [dbo].Module ([ModuleId])
ON DELETE CASCADE
GO