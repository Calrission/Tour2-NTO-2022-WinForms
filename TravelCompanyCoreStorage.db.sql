BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "ClientTypes" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_ClientTypes" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Contacts" (
	"Id"	TEXT NOT NULL,
	"FirstName"	TEXT,
	"LastName"	TEXT,
	"PatronymicName"	TEXT,
	"EmailAddress"	TEXT,
	"PhoneNumber"	TEXT,
	CONSTRAINT "PK_Contacts" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Foods" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_Foods" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "PaymentTypes" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_PaymentTypes" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Regions" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT,
	"Description"	TEXT,
	CONSTRAINT "PK_Regions" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Roles" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT,
	"Description"	TEXT,
	"isSystem"	INTEGER NOT NULL,
	CONSTRAINT "PK_Roles" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "TourOrderPayments" (
	"Id"	TEXT NOT NULL,
	"TourOrderId"	TEXT NOT NULL,
	"PaymentDate"	TEXT,
	"TotalCost"	REAL,
	CONSTRAINT "PK_TourOrderPayments" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "TourOrderStatuses" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_TourOrderStatuses" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "TourOrderStatusReasons" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	CONSTRAINT "PK_TourOrderStatusReasons" PRIMARY KEY("Id")
);
CREATE TABLE IF NOT EXISTS "Clients" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT NOT NULL,
	"ContactId"	TEXT NOT NULL,
	"ClientTypeId"	TEXT NOT NULL,
	"PhoneNumber"	TEXT NOT NULL,
	CONSTRAINT "PK_Clients" PRIMARY KEY("Id"),
	CONSTRAINT "FK_Clients_ClientTypes_ClientTypeId" FOREIGN KEY("ClientTypeId") REFERENCES "ClientTypes"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_Clients_Contacts_ContactId" FOREIGN KEY("ContactId") REFERENCES "Contacts"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Hotels" (
	"Id"	TEXT NOT NULL,
	"Name"	TEXT,
	"Description"	TEXT,
	"PhoneNumber"	TEXT,
	"RegionId"	TEXT,
	"ManagerId"	TEXT,
	CONSTRAINT "PK_Hotels" PRIMARY KEY("Id"),
	CONSTRAINT "FK_Hotels_Contacts_ManagerId" FOREIGN KEY("ManagerId") REFERENCES "Contacts"("Id"),
	CONSTRAINT "FK_Hotels_Regions_RegionId" FOREIGN KEY("RegionId") REFERENCES "Regions"("Id")
);
CREATE TABLE IF NOT EXISTS "ContactRole" (
	"ContactsId"	TEXT NOT NULL,
	"RolesId"	TEXT NOT NULL,
	CONSTRAINT "PK_ContactRole" PRIMARY KEY("ContactsId","RolesId"),
	CONSTRAINT "FK_ContactRole_Roles_RolesId" FOREIGN KEY("RolesId") REFERENCES "Roles"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_ContactRole_Contacts_ContactsId" FOREIGN KEY("ContactsId") REFERENCES "Contacts"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "TourOrderRealizations" (
	"Id"	TEXT NOT NULL,
	"ClientId"	TEXT NOT NULL,
	"PaymentTypeId"	TEXT NOT NULL,
	"TotalCost"	REAL,
	"BookingConfirmation"	INTEGER NOT NULL,
	"RealizationDate"	TEXT,
	"TourOrderId"	TEXT NOT NULL,
	CONSTRAINT "PK_TourOrderRealizations" PRIMARY KEY("Id"),
	CONSTRAINT "FK_TourOrderRealizations_PaymentTypes_PaymentTypeId" FOREIGN KEY("PaymentTypeId") REFERENCES "PaymentTypes"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_TourOrderRealizations_Clients_ClientId" FOREIGN KEY("ClientId") REFERENCES "Clients"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "TourOrders" (
	"Id"	TEXT NOT NULL,
	"ClientId"	TEXT NOT NULL,
	"PaymentTypeId"	TEXT NOT NULL,
	"TotalCost"	REAL,
	"TourOrderStatusId"	TEXT NOT NULL,
	"TourOrderStatusShiftDate"	TEXT,
	"TourOrderStatusReasonId"	TEXT NOT NULL,
	CONSTRAINT "PK_TourOrders" PRIMARY KEY("Id"),
	CONSTRAINT "FK_TourOrders_TourOrderStatuses_TourOrderStatusId" FOREIGN KEY("TourOrderStatusId") REFERENCES "TourOrderStatuses"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_TourOrders_Clients_ClientId" FOREIGN KEY("ClientId") REFERENCES "Clients"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_TourOrders_TourOrderStatusReasons_TourOrderStatusReasonId" FOREIGN KEY("TourOrderStatusReasonId") REFERENCES "TourOrderStatusReasons"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_TourOrders_PaymentTypes_PaymentTypeId" FOREIGN KEY("PaymentTypeId") REFERENCES "PaymentTypes"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "Tours" (
	"Id"	TEXT NOT NULL,
	"HotelId"	TEXT NOT NULL,
	"StartDateTime"	TEXT NOT NULL,
	"EndDateTime"	TEXT NOT NULL,
	"NightsAmount"	INTEGER NOT NULL,
	"DaysAmount"	INTEGER NOT NULL,
	"FoodId"	TEXT NOT NULL,
	"Cost"	REAL NOT NULL,
	"Description"	TEXT NOT NULL,
	CONSTRAINT "PK_Tours" PRIMARY KEY("Id"),
	CONSTRAINT "FK_Tours_Foods_FoodId" FOREIGN KEY("FoodId") REFERENCES "Foods"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_Tours_Hotels_HotelId" FOREIGN KEY("HotelId") REFERENCES "Hotels"("Id") ON DELETE CASCADE
);
CREATE TABLE IF NOT EXISTS "TourOrderItems" (
	"Id"	TEXT NOT NULL,
	"TourOrderId"	TEXT NOT NULL,
	"TourId"	TEXT NOT NULL,
	"Quantity"	INTEGER NOT NULL,
	"Price"	REAL NOT NULL,
	"Cost"	REAL NOT NULL,
	"TourOrderRealizationId"	TEXT,
	CONSTRAINT "PK_TourOrderItems" PRIMARY KEY("Id"),
	CONSTRAINT "FK_TourOrderItems_TourOrders_TourOrderId" FOREIGN KEY("TourOrderId") REFERENCES "TourOrders"("Id") ON DELETE CASCADE,
	CONSTRAINT "FK_TourOrderItems_TourOrderRealizations_TourOrderRealizationId" FOREIGN KEY("TourOrderRealizationId") REFERENCES "TourOrderRealizations"("Id"),
	CONSTRAINT "FK_TourOrderItems_Tours_TourId" FOREIGN KEY("TourId") REFERENCES "Tours"("Id") ON DELETE CASCADE
);
INSERT INTO "ClientTypes" VALUES ('65BC9547-ACD5-420E-8D60-0F037BFC4E79','юридическое лицо');
INSERT INTO "ClientTypes" VALUES ('CD3B7458-6F73-49C3-A56B-AF81101CC3CD','физическое лицо');
INSERT INTO "Contacts" VALUES ('242B1D5F-9103-474A-AEC4-F9143E87D58B','Николай','Епифанов','Александрович','kolyaepifan@yandex.ru','+79536789123');
INSERT INTO "Contacts" VALUES ('264FD9D1-0E27-4609-B7CD-344FB3FD044F','Петр','Лебедихин','Степанович','lebedichp@yandex.ru','+79091256789');
INSERT INTO "Contacts" VALUES ('4B37D5EF-0A58-4EDC-9E57-953C59E46BA4','Степан','Порожнев','Аркадиевич','stepaporozhnev@gmail.com','+75376432905');
INSERT INTO "Contacts" VALUES ('EE91E6A7-CB38-4DB0-B702-04D0903CF231','Пахом','Бот','','','');
INSERT INTO "Foods" VALUES ('5BFBCEF2-0ACB-4D1C-B718-35745F46BC07','3-х разовое');
INSERT INTO "Foods" VALUES ('A1E10F82-C118-483F-ADDE-6D9F1162F03D','с завтраком');
INSERT INTO "Foods" VALUES ('F3AB28B7-B8A7-4C82-8584-335C58F2D000','без питания');
INSERT INTO "PaymentTypes" VALUES ('4322B228-5CBC-4291-959A-F71222949833','Кредит');
INSERT INTO "PaymentTypes" VALUES ('9C67C785-C4A8-4576-8D52-205DCBB4F997','Предоплата');
INSERT INTO "Regions" VALUES ('07335F3B-154B-4B5A-8323-342B5B8ABC90','Санкт-Петербург','Хорошее место для необычного туризма');
INSERT INTO "Regions" VALUES ('8FF98E1D-F2BA-4D2B-A3F7-A794755734A8','Москва','Прекрасный город с прекрасной архитектурой!');
INSERT INTO "Regions" VALUES ('BAB8EABB-C79D-4969-9869-89F1F048F692','Электросталь','Родной город участников команды');
INSERT INTO "Roles" VALUES ('514F8200-EB0E-4241-9114-C7CBB6E5AC2F','Менеджер','Управляющий делами отеля',1);
INSERT INTO "Roles" VALUES ('6068F976-B092-475B-A8AB-BEA2DD2EDBBA','Контакт клиента','Представляет интересы клиента',1);
INSERT INTO "Roles" VALUES ('DA03F4BA-ED97-481B-8A47-ED885E08B6B5','Администратор','Человек, который может ВСЁ',1);
INSERT INTO "TourOrderPayments" VALUES ('064692D0-A0B6-4EFA-9A44-61979709095D','3E392283-82C6-4679-A690-49E3F670E3FF','2022-12-11 22:40:28.6341759',120960.0);
INSERT INTO "TourOrderStatuses" VALUES ('0A593624-6F2F-4FEA-BFF3-0A67904DE4E1','Отмена');
INSERT INTO "TourOrderStatuses" VALUES ('47E57AA5-7BFE-45BE-A017-C41903F40068','Действует');
INSERT INTO "TourOrderStatuses" VALUES ('4A31DF95-6013-4AC7-AA88-C7E9ED348E02','Продан');
INSERT INTO "TourOrderStatuses" VALUES ('5F24C6F9-704A-403A-B30B-04E2F361A403','Бронь');
INSERT INTO "TourOrderStatuses" VALUES ('D40D224C-D35A-4E2E-9D85-4EFAF3CA701E','Оплачен');
INSERT INTO "TourOrderStatuses" VALUES ('DDEB0FF0-7E89-425D-AF37-7D97F5571F5B','Черновик');
INSERT INTO "TourOrderStatuses" VALUES ('DFFE7872-A3C0-436E-84BA-29BDCB3FAF94','Завершён');
INSERT INTO "TourOrderStatusReasons" VALUES ('12C563CD-03EA-41EF-9377-6955387F8702','Беспричинно');
INSERT INTO "TourOrderStatusReasons" VALUES ('2B5E1848-E7C3-48BE-8472-7387798C5818','Истечение срока бронирования');
INSERT INTO "TourOrderStatusReasons" VALUES ('7C8D58AB-92EA-4059-A097-5D3E5928C3CB','Отказ клиента');
INSERT INTO "TourOrderStatusReasons" VALUES ('9D4B962C-460B-4BD5-B8A5-F8636FA82284','Отказ Отеля');
INSERT INTO "Clients" VALUES ('6D97731C-8408-4430-9C71-072842173FD4','Турагенство «Ромашка»','242B1D5F-9103-474A-AEC4-F9143E87D58B','65BC9547-ACD5-420E-8D60-0F037BFC4E79','?????');
INSERT INTO "Clients" VALUES ('7DC4F070-A620-4A92-AA80-D4C099B836BE','Сидоров Сысой Свиридович','EE91E6A7-CB38-4DB0-B702-04D0903CF231','CD3B7458-6F73-49C3-A56B-AF81101CC3CD','+71011121212');
INSERT INTO "Clients" VALUES ('87F50D79-1C38-47CE-ACF6-0A7AA6DE3FBD','Агенство «Васильки»','242B1D5F-9103-474A-AEC4-F9143E87D58B','65BC9547-ACD5-420E-8D60-0F037BFC4E79','?????');
INSERT INTO "Hotels" VALUES ('1143FCDF-3C64-4D0F-8110-B788F906D03F','Гостиница «Космос»','Дотянись до звезды, почувствуй себя свободным, космические цены, необычный интерьер, после посещения нашей гостиницы у Вас останутся неземные впечатления ','+75376432905','8FF98E1D-F2BA-4D2B-A3F7-A794755734A8','4B37D5EF-0A58-4EDC-9E57-953C59E46BA4');
INSERT INTO "Hotels" VALUES ('4F9BF633-0841-434D-BAB5-3593F7D01D68','Прибрежные волны','Качеством своих услуг Прибрежные волны бьют любой отель в России, как камни об берег, и по весьма сходной цене','+79091256789','8FF98E1D-F2BA-4D2B-A3F7-A794755734A8','264FD9D1-0E27-4609-B7CD-344FB3FD044F');
INSERT INTO "Hotels" VALUES ('952856FA-1655-425B-9635-6FE13A8E35FF','Гостиница «Чистый лист»','Перезагрузись и начни все с нового листа, прекрасные апартаменты, обслуживание на высоте, приемлемые цены ','+79536789123','BAB8EABB-C79D-4969-9869-89F1F048F692','242B1D5F-9103-474A-AEC4-F9143E87D58B');
INSERT INTO "Hotels" VALUES ('430C3724-0BD2-4087-B0C4-16EF4AB63F6C','Ленинград','Одноимённая гостиница','+7(322) 223-3222','07335F3B-154B-4B5A-8323-342B5B8ABC90','242B1D5F-9103-474A-AEC4-F9143E87D58B');
INSERT INTO "ContactRole" VALUES ('242B1D5F-9103-474A-AEC4-F9143E87D58B','514F8200-EB0E-4241-9114-C7CBB6E5AC2F');
INSERT INTO "ContactRole" VALUES ('242B1D5F-9103-474A-AEC4-F9143E87D58B','6068F976-B092-475B-A8AB-BEA2DD2EDBBA');
INSERT INTO "ContactRole" VALUES ('264FD9D1-0E27-4609-B7CD-344FB3FD044F','514F8200-EB0E-4241-9114-C7CBB6E5AC2F');
INSERT INTO "ContactRole" VALUES ('264FD9D1-0E27-4609-B7CD-344FB3FD044F','DA03F4BA-ED97-481B-8A47-ED885E08B6B5');
INSERT INTO "ContactRole" VALUES ('4B37D5EF-0A58-4EDC-9E57-953C59E46BA4','514F8200-EB0E-4241-9114-C7CBB6E5AC2F');
INSERT INTO "ContactRole" VALUES ('EE91E6A7-CB38-4DB0-B702-04D0903CF231','6068F976-B092-475B-A8AB-BEA2DD2EDBBA');
INSERT INTO "TourOrderRealizations" VALUES ('EB10C1E4-97AA-4B0D-84BF-862DD874E2D0','87F50D79-1C38-47CE-ACF6-0A7AA6DE3FBD','9C67C785-C4A8-4576-8D52-205DCBB4F997',120960.0,1,'2022-12-11 22:40:33.3456781','3E392283-82C6-4679-A690-49E3F670E3FF');
INSERT INTO "TourOrders" VALUES ('A34BFFFF-4EA4-4D93-A076-D6E7E5EBE800','6D97731C-8408-4430-9C71-072842173FD4','9C67C785-C4A8-4576-8D52-205DCBB4F997',30300.0,'0A593624-6F2F-4FEA-BFF3-0A67904DE4E1','2022-12-11 22:40:55.2973759','2B5E1848-E7C3-48BE-8472-7387798C5818');
INSERT INTO "TourOrders" VALUES ('3E392283-82C6-4679-A690-49E3F670E3FF','87F50D79-1C38-47CE-ACF6-0A7AA6DE3FBD','9C67C785-C4A8-4576-8D52-205DCBB4F997',120960.0,'4A31DF95-6013-4AC7-AA88-C7E9ED348E02','2022-12-11 22:40:33.344991','12C563CD-03EA-41EF-9377-6955387F8702');
INSERT INTO "Tours" VALUES ('CF85F077-0327-4847-9889-D90046B6EEFE','1143FCDF-3C64-4D0F-8110-B788F906D03F','2022-12-11 12:00:00','2022-12-24 14:00:00',13,14,'5BFBCEF2-0ACB-4D1C-B718-35745F46BC07',10000.0,'');
INSERT INTO "Tours" VALUES ('73F13C14-EE53-4087-BB78-F0DAB99062E5','4F9BF633-0841-434D-BAB5-3593F7D01D68','2022-12-11 12:00:00','2022-12-11 14:00:00',0,1,'A1E10F82-C118-483F-ADDE-6D9F1162F03D',18880.0,'');
INSERT INTO "Tours" VALUES ('D31089BB-A92F-4819-8D0D-507D9C1C17F9','952856FA-1655-425B-9635-6FE13A8E35FF','2022-12-11 12:00:00','2022-12-24 14:00:00',13,14,'F3AB28B7-B8A7-4C82-8584-335C58F2D000',100.0,'');
INSERT INTO "Tours" VALUES ('61AE6192-72BB-41D9-A8DB-A04705CFF425','430C3724-0BD2-4087-B0C4-16EF4AB63F6C','2022-12-11 12:00:00','2022-12-28 14:00:00',17,18,'5BFBCEF2-0ACB-4D1C-B718-35745F46BC07',17680.0,'');
INSERT INTO "TourOrderItems" VALUES ('BB5F3506-1D21-411E-B83C-AD0E40EDF970','A34BFFFF-4EA4-4D93-A076-D6E7E5EBE800','CF85F077-0327-4847-9889-D90046B6EEFE',3,10000.0,30000.0,NULL);
INSERT INTO "TourOrderItems" VALUES ('E94568FB-7976-4AB1-B8BA-E58743EB0783','A34BFFFF-4EA4-4D93-A076-D6E7E5EBE800','D31089BB-A92F-4819-8D0D-507D9C1C17F9',3,100.0,300.0,NULL);
INSERT INTO "TourOrderItems" VALUES ('850F98DD-22E4-4B97-AB9E-9F9C50FD8FB0','3E392283-82C6-4679-A690-49E3F670E3FF','61AE6192-72BB-41D9-A8DB-A04705CFF425',4,16980.0,67920.0,NULL);
INSERT INTO "TourOrderItems" VALUES ('F811F1ED-059D-49F6-94BC-8D8F0B81F2DD','3E392283-82C6-4679-A690-49E3F670E3FF','61AE6192-72BB-41D9-A8DB-A04705CFF425',3,17680.0,53040.0,NULL);
CREATE INDEX IF NOT EXISTS "IX_Clients_ClientTypeId" ON "Clients" (
	"ClientTypeId"
);
CREATE INDEX IF NOT EXISTS "IX_Clients_ContactId" ON "Clients" (
	"ContactId"
);
CREATE INDEX IF NOT EXISTS "IX_ContactRole_RolesId" ON "ContactRole" (
	"RolesId"
);
CREATE INDEX IF NOT EXISTS "IX_Hotels_ManagerId" ON "Hotels" (
	"ManagerId"
);
CREATE INDEX IF NOT EXISTS "IX_Hotels_RegionId" ON "Hotels" (
	"RegionId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrderItems_TourId" ON "TourOrderItems" (
	"TourId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrderItems_TourOrderId" ON "TourOrderItems" (
	"TourOrderId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrderItems_TourOrderRealizationId" ON "TourOrderItems" (
	"TourOrderRealizationId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrderRealizations_ClientId" ON "TourOrderRealizations" (
	"ClientId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrderRealizations_PaymentTypeId" ON "TourOrderRealizations" (
	"PaymentTypeId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrders_ClientId" ON "TourOrders" (
	"ClientId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrders_PaymentTypeId" ON "TourOrders" (
	"PaymentTypeId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrders_TourOrderStatusId" ON "TourOrders" (
	"TourOrderStatusId"
);
CREATE INDEX IF NOT EXISTS "IX_TourOrders_TourOrderStatusReasonId" ON "TourOrders" (
	"TourOrderStatusReasonId"
);
CREATE INDEX IF NOT EXISTS "IX_Tours_FoodId" ON "Tours" (
	"FoodId"
);
CREATE INDEX IF NOT EXISTS "IX_Tours_HotelId" ON "Tours" (
	"HotelId"
);
CREATE VIEW RawTOIs as 
select t.Id as TourId, h.Name || ' ' || (cast(DaysAmount as text) || ' дней/') || (cast(NightsAmount as text) || ' ночей c ')  || (cast(StartDateTime as text)) as TourName,
tos.Name as StatusName
from tourorderitems as toi
inner join TourOrders as tt on tt.Id=toi.TourOrderId
inner join Tours t on t.Id=toi.TourId
inner join Hotels h on h.Id=t.HotelId
inner join TourOrderStatuses tos on tos.Id=tt.TourOrderStatusId;
COMMIT;