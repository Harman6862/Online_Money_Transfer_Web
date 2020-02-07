SET IDENTITY_INSERT [dbo].[MoneyTransfer] ON
INSERT INTO [dbo].[MoneyTransfer] ([Id], [TransferAmount], [TransferDateTime], [MoneySenderId], [MoneyReceiverId], [ProviderId]) VALUES (1, CAST(300.00 AS Decimal(18, 2)), N'2020-01-23 09:12:00', 1, 1, 1)
INSERT INTO [dbo].[MoneyTransfer] ([Id], [TransferAmount], [TransferDateTime], [MoneySenderId], [MoneyReceiverId], [ProviderId]) VALUES (2, CAST(500.00 AS Decimal(18, 2)), N'2020-01-30 22:12:00', 2, 2, 2)
SET IDENTITY_INSERT [dbo].[MoneyTransfer] OFF
