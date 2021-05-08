INSERT INTO Products (Name,DeliveryCost,Weight,Description) VALUES
    ('Gitara klasyczna 4/4', 35.59, 2.5, 'Brak futerału - należy przewozić ostrożnie.'),
    ('Kubek termiczny TOP MOUNTAIN', 8.12, 0.35, 'Do każdego kubka proszę dokleić na karton cenę!'),
    ('Grzejnik panelowy żeberkowy', 35.15, 13.25, 'Ciężki, proszę o nieprzewracanie go do góry nogami, ponieważ jest już w nim olej.'),
    ('Lampka nocna Romantic', 3.12, 0.34, ''),
    ('Karta graficzna XX852', 32.11, 0.55, 'Nie trzymać pudełka w wilgotnym miejscu!')


INSERT INTO Addresses (City, Street, Nr, ZipCode) VALUES
    ('Łódź','Dożynkowa','89','94-279'),
    ('Warszawa','Husarska','116/1a','05-077'),
    ('Katowice','Koników Polnych','6','40-644'),
    ('Kielce','Piotra Michałowskiego','32','25-809'),
    ('Wrocław','Henryka Wieniawskiego','37/45','51-611'),
    ('Kraków','Dróżka','13','30-698')

INSERT INTO Addresses (Nation, City, Street, Nr, ZipCode) VALUES
    ('Stany Zjednoczone','New York','Bottom Lane','1568','14-052'),
    ('Norwegia','Bodó','General Fleischers','1505/22c','80-003')


INSERT INTO Clients (Name,Hash,Role,AddressID,Phone) VALUES
    ('Admin','ag5nv0ermcCsm2ASf',1,2,'+48 795 5530 09'),
    ('Jesionowe Gitary - Baranowski','aSfg7t6im32fim12$',3,5,'+48 435 234 471'),
    ('Abramics Polska','vmsdietvbt14',3,1,'+48 104 344 512'),
    ('NY Abroad Company','&tn&44vfrvbtdkm',4,7,'+1 108 405 663'),
    ('Almeria Dunno','ovonr,wpe@4fcace',3,1,'+48 606 707 123')


INSERT INTO Orders (ProductID,DeliveryAddressID,ClientID,Status) VALUES
    (1,4,2,1),
    (1,2,2,1),
    (1,6,2,3),
    (1,5,2,3),
    (1,1,2,2),
    (3,2,1,3),
    (4,2,3,1),
    (4,2,3,1),
    (5,2,5,1),
    (2,2,5,1),
    (4,2,4,1),
    (5,2,4,1),
    (1,4,2,1),
    (1,4,3,1)

INSERT INTO History(ClientID,OrderID,Action) VALUES
    (1,3,1),
    (2,5,1),
    (5,4,4),
    (4,2,3),
    (3,5,4),
    (5,5,4),
    (5,2,3),
    (2,1,1),
    (2,1,2)

