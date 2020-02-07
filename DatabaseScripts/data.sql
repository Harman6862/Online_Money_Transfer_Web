SET IDENTITY_INSERT [dbo].[MoneyReceiver] ON
INSERT INTO [dbo].[MoneyReceiver] ([Id], [ReceiverName], [MobileNumber]) VALUES (1, N'Chris Davis', N'021444456789')
INSERT INTO [dbo].[MoneyReceiver] ([Id], [ReceiverName], [MobileNumber]) VALUES (2, N'Mary James', N'021555678966')
SET IDENTITY_INSERT [dbo].[MoneyReceiver] OFF
SET IDENTITY_INSERT [dbo].[MoneySender] ON
INSERT INTO [dbo].[MoneySender] ([Id], [SenderName], [MobileNumber]) VALUES (1, N'Jackson William', N'021333456789')
INSERT INTO [dbo].[MoneySender] ([Id], [SenderName], [MobileNumber]) VALUES (2, N'Neil Williams', N'022666789032')
SET IDENTITY_INSERT [dbo].[MoneySender] OFF
SET IDENTITY_INSERT [dbo].[Provider] ON
INSERT INTO [dbo].[Provider] ([Id], [ProviderName], [ProviderWebURL]) VALUES (1, N'Money Gram', N'http://www.moneygram.com')
INSERT INTO [dbo].[Provider] ([Id], [ProviderName], [ProviderWebURL]) VALUES (2, N'Western Union ', N'http://www.westernunion.com')
SET IDENTITY_INSERT [dbo].[Provider] OFF
SET IDENTITY_INSERT [dbo].[MoneyTransfer] ON
INSERT INTO [dbo].[MoneyTransfer] ([Id], [TransferAmount], [TransferDateTime], [MoneySenderId], [MoneyReceiverId], [ProviderId]) VALUES (1, CAST(300.00 AS Decimal(18, 2)), N'2020-01-23 09:12:00', 1, 1, 1)
INSERT INTO [dbo].[MoneyTransfer] ([Id], [TransferAmount], [TransferDateTime], [MoneySenderId], [MoneyReceiverId], [ProviderId]) VALUES (2, CAST(500.00 AS Decimal(18, 2)), N'2020-01-30 22:12:00', 2, 2, 2)
SET IDENTITY_INSERT [dbo].[MoneyTransfer] OFF
