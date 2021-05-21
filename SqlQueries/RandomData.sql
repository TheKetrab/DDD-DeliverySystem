INSERT INTO Products (Name,DeliveryCost,Weight,Description) VALUES
    ('Gitara klasyczna 4/4', 35.59, 2.5, 'Brak futerału - należy przewozić ostrożnie.'),
    ('Kubek termiczny TOP MOUNTAIN', 8.12, 0.35, 'Do każdego kubka proszę dokleić na karton cenę!'),
    ('Grzejnik panelowy żeberkowy', 35.15, 13.25, 'Ciężki, proszę o nieprzewracanie go do góry nogami, ponieważ jest już w nim olej.'),
    ('Lampka nocna Romantic', 3.12, 0.34, ''),
    ('Karta graficzna XX852', 32.11, 0.55, 'Nie trzymać pudełka w wilgotnym miejscu!')

INSERT INTO Nations (Name) VALUES 
    ('Polska'),
    ('Stany Zjednoczone'),
    ('Norwegia')


INSERT INTO Addresses (City, Street, Nr, ZipCode) VALUES
    ('Łódź','Dożynkowa','89','94-279'),
    ('Warszawa','Husarska','116/1a','05-077'),
    ('Katowice','Koników Polnych','6','40-644'),
    ('Kielce','Piotra Michałowskiego','32','25-809'),
    ('Wrocław','Henryka Wieniawskiego','37/45','51-611'),
    ('Kraków','Dróżka','13','30-698')

INSERT INTO Addresses (NationId, City, Street, Nr, ZipCode) VALUES
    (2, 'New York','Bottom Lane','1568','14-052'),
    (3, 'Bodó','General Fleischers','1505/22c','80-003')


INSERT INTO Clients (Name,Email,Hash,Role,AddressID,Phone) VALUES
    ('Admin','admin@gmail.com','0x1fd4c742b205b5ac36e555ebd85e4d3a428f1245dd6ce4dc',1,2,'+48 795 5530 09'),
    ('Jesionowe Gitary - Baranowski','mail2@gmail.com','0x1fd4c742b205b5ac36e555ebd85e4d3a428f1245dd6ce4dc',3,5,'+48 435 234 471'),
    ('Abramics Polska','mail3@gmail.com','0x1fd4c742b205b5ac36e555ebd85e4d3a428f1245dd6ce4dc',3,1,'+48 104 344 512'),
    ('NY Abroad Company','mail4@gmail.com','0x1fd4c742b205b5ac36e555ebd85e4d3a428f1245dd6ce4dc',4,7,'+1 108 405 663'),
    ('Almeria Dunno','mail5@gmail.com','0x1fd4c742b205b5ac36e555ebd85e4d3a428f1245dd6ce4dc',3,1,'+48 606 707 123')

INSERT INTO Orders (DeliveryAddressId, OwnerId, Status, LatestDate) VALUES
    (2, 1, 3, '20200122'),
    (3, 1, 5, '20221028'),
    (1, 2, 3, '20170317'),
    (2, 2, 1, '20211231'),
    (4, 2, 1, '20190914'),
    (3, 3, 1, '20200803'),
    (5, 3, 1, '20170201'),
    (4, 4, 1, '20130819'),
    (6, 5, 1, '20240514'),
    (7, 5, 1, '20220214'),
    (4, 5, 1, '20010101')


