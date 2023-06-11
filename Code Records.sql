
EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'
GO
EXEC sp_MSForEachTable 'DELETE FROM ?'
GO
EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'
GO

INSERT INTO vaccine_type (vaccine_code, vaccine_name, country_of_origin, note)
VALUES
(N'VC001', N'Vaccine Care', NULL, N'Vaccine Care có tác dụng kích thích gây phản ứng miễn dịch học, tạo kháng thể chủ động cho chó được tiêm, phòng chống lại bệnh do vi rút Care cường độc gây ra'),
(N'VC002', N'Vaccine Parvo', NULL, N'Vaccine kích thích gây phản ứng miễn dịch học, tạo kháng thể chủ động cho chó được chủng ngừa, giúp chó phòng bệnh viêm ruột hoại tử do Parvovirus cường độc gây ra'),
(N'VC003', N'MLV CAV-1', NULL, N'Vaccine tiêm phòng bệnh viêm gan truyền nhiễm ở chó'),
(N'VC004', N'MLV CAV-2', NULL, N'Vaccine tiêm phòng bệnh viêm gan truyền nhiễm ở chó'),
(N'VC005', N'Vaccine 5 bệnh ở chó', NULL, N'Vaccine phòng 5 bệnh Care virus, Parvo virus, viêm gan truyền nhiễm, ho cũi chó, phổi cúm ở chó'),
(N'VC006', N'Vaccine 7 bệnh ở chó', NULL, N'Vaccine phòng 7 bệnh viêm ruột, viêm gan, cúm, bệnh nghệ Do leptospira Canicola, bệnh nghệ do Do leptospira Icterohaemorrhagiae, viêm ruột do coronavirus, Cannine Distemper Virus'),
(N'VC007', N'Rabisin', NULL, N'Vaccine phòng bệnh chó mèo dại'),
(N'VC008', N'Vaccine 3 bệnh ở mèo', NULL, N'Phòng bệnh Giảm bạch cầu, Viêm mũi - khí quản truyền nhiễm, Hô hấp do Herpevirus'),
(N'VC009', N'Leucorifelin', NULL, N'Vaccine 4 trong 1 (Giảm bạch cầu, Viêm mũi - khí quản truyền nhiễm, bệnh do Herpesvirus) ở mèo'),
(N'VC010', N'Purevax', NULL, N'Vaccine 4 trong 1 (Giảm bạch cầu, Viêm mũi - khí quản truyền nhiễm, bệnh do Herpesvirus) ở mèo'),
(N'VC011', N'Novibac', NULL, N'Vaccine tiêm phòng 4 bệnh ở mèo'),
(N'VC012', N'Zoetis', NULL, N'Vaccine tiêm phòng 4 bệnh ở mèo');


INSERT INTO disease (disease_code, disease_name)
VALUES 
(N'DS001', N'Care virus'),
(N'DS002', N'Parvo virus'),
(N'DS003', N'Viêm gan truyền nhiễm'),
(N'DS004', N'Ho cũi chó'),
(N'DS005', N'Phó cúm'),
(N'DS006', N'Leptospria'),
(N'DS007', N'Coronavirus'),
(N'DS008', N'Herpervirus'),
(N'DS009', N'Giảm bạch cầu'),
(N'DS010', N'Viêm mũi – Khí quản truyền nhiễm ở mèo'),
(N'DS011', N'Herpesvirus'),
(N'DS012', N'Bệnh chó dại'),
(N'DS013', N'Nhiễm trùng calicivirus ở mèo'),
(N'DS014', N'Xuất huyết truyền nhiễm ở thỏ'),
(N'DS015', N'Bại huyết do virus ở thỏ'),
(N'DS016', N'Tụ huyết trùng ở thỏ'),
(N'DS017', N'Cầu trùng ở thỏ'),
(N'DS018', N'Xuất huyết ở thỏ (RHDV)'),
(N'DS019', N'Bệnh nghệ Do leptospira Canicola'),
(N'DS020', N'Bệnh nghệ Do leptospira Icterohaemorrhagiae'),
(N'DS021', N'Bệnh mèo dại'),
(N'DS022', N'Bệnh hô hấp do Herpevirus');

INSERT INTO vaccine_compatible (disease_code, vaccine_code)
VALUES
(N'DS001', N'VC001'),
(N'DS002', N'VC002'),
(N'DS003', N'VC003'),
(N'DS003', N'VC004'),
(N'DS001', N'VC005'),
(N'DS002', N'VC006'),
(N'DS012', N'VC007'),
(N'DS009', N'VC009'),
(N'DS009', N'VC010'),
(N'DS009', N'VC011'),
(N'DS009', N'VC012');

INSERT INTO account (username, password, name, phone, email, address, birthday, account_init_day, isTerminated, account_type, avatar)
VALUES
(N'admin', N'admin', N'Lãnh chúa', NULL, NULL, NULL, N'2023-05-05', NULL, NULL, 0, NULL),
(N'client', N'client', N'Tùng Nguyễn', N'09123451', N'N/A', N'N/A', N'2023-05-05', NULL, NULL, 1, NULL),
(N'doctor', N'doctor', N'Lê hoàng mạnh', N'091304122', N'N/A', N'N/A', N'2023-05-05', NULL, NULL, 2, NULL),
(N'doctor2', N'doctor', N'Thành Lâm', NULL, NULL, NULL, N'2023-05-05', NULL, NULL, 2, NULL),
(N'toilaadmin', N'admin', N'Võ Ác Min', N'987654321', NULL, NULL, N'2003-08-27', N'2023-04-18', NULL, 0, NULL),
(N'toilabacsi1', N'1', N'Võ Đóc Tơ', NULL, NULL, NULL, NULL, NULL, NULL, 2, NULL),
(N'toiladuocsi123', N'duocsi123', N'Trần Dược Sĩ', N'123456789', N'duocsi1@gmail.com', NULL, N'2003-08-27', NULL, NULL, 3, NULL),
(N'toilaguest1', N'1', N'Hoàng Văn Guét', NULL, NULL, NULL, NULL, NULL, NULL, 1, NULL),
(N'toilakhachhang1', N'khachhang1', N'Khách Hàng Một', N'111111111', N'khachhang1@gmail.com', N'18 Điện Biên Phủ', N'2010-10-10', N'2023-04-14', NULL, 1, NULL),
(N'toilakhachhang123', N'khachhang123', N'Võ Khách Hàng', N'0932424045', N'khachhang@gmai.com', N'20 Nguyễn Hoàng', N'2001-01-30', N'2023-12-03', NULL, 5, NULL),
(N'toilakhachhang2', N'khachhang2', N'Khách Hàng Hai', N'222222222', N'khachhang2@gmail.com', N'19 Hoàng Thùy Linh', N'2009-09-09', N'2023-02-02', NULL, 1, NULL),
(N'toilakhachhang3', N'khachhang3', N'Khách Hàng Ba', N'33333333', N'khachhang3@gmail.com', N'88 Đen Vâu', N'2009-09-09', N'2023-02-02', NULL, 1, NULL),
(N'toilakhachhang4', N'khachhang4', N'Khách Hàng Bốn', N'44444444', N'khachhang4@gmail.com', N'109 Chi Pu', N'2009-09-09', N'2023-03-03', NULL, 1, NULL),
(N'toilathungan123', N'thungan123', N'Võ Thu Ngân', N'999999999', N'thungan@gmail.com', N'19 Hoàng Ngân Thu', N'2000-09-20', N'2023-04-22', NULL, 4, NULL);


INSERT INTO breed (breed_id, breed_name)
VALUES
(N'br001', N'Chó'),
(N'br002', N'Mèo'),
(N'br003', N'Thằn lằn'),
(N'br004', N'Vẹt');

INSERT INTO client (username, total_pay)
VALUES
(N'client', NULL),
(N'toilakhachhang1', NULL),
(N'toilakhachhang123', NULL),
(N'toilakhachhang2', NULL),
(N'toilakhachhang3', NULL),
(N'toilakhachhang4', NULL);

INSERT INTO pharmacist (username, salary)
VALUES
(N'toiladuocsi123', NULL);

INSERT INTO doctor (username, breed_id, salary, experience, education)
VALUES
(N'doctor', NULL, NULL, N'Không có', N'- Tốt nghiệp cao đẳng Bhsc
     - Thạc sĩ NCOA
- Tiến sĩ k3283sq'),
(N'doctor2', NULL, NULL, NULL, NULL);


INSERT INTO doctor_major (doctor_username, breed_id)
VALUES
(N'doctor', N'br001');

INSERT INTO pet (pet_id, breed_id, client_username, pet_name, age, weight)
VALUES 
(N'pet_2', N'br003', N'client', N'hai2456', 532, 876),
(N'pet_3', N'br001', N'client', N'Pinochio23458888', 123, 2),
(N'pet_4', N'br004', N'client', N'da vàng okoo', 6, 0),
(N'pet_5', N'br001', N'client', N'Adam', 6, 8931),
(N'pet_6', N'br004', N'client', N'vẹt màu nâu', 0, 0),
(N'pet_7', N'br004', N'client', N'vẹt mỏm xanh', 69, 96),
(N'pet_8', N'br001', N'toilakhachhang1', N'Perry', 2, 15),
(N'pet_9', N'br002', N'toilakhachhang1', N'VinMart', 3, 2);

INSERT INTO appointment (appointment_id, pet_id, doctor_username, state, init_day, date, note)
VALUES 
(N'app_2', N'pet_2', NULL, 0, N'2023-04-26 17:08:41.780', N'2023-04-26 17:08:00.000', NULL),
(N'app_3', N'pet_3', N'doctor', 2, N'2023-04-26 17:08:50.963', N'2023-04-17 17:08:00.000', N'đây là con pino'),
(N'app_4', N'pet_5', NULL, 0, N'2023-04-26 17:08:59.163', N'2023-04-01 17:08:00.000', N'đây là adam'),
(N'app_5', N'pet_4', NULL, 0, N'2023-04-26 17:09:09.210', N'2023-04-17 17:09:00.000', N'lại là da vàng'),
(N'app_6', N'pet_6', N'doctor', 1, N'2023-04-26 17:10:30.910', N'2023-05-29 17:10:00.000', N'dsdsdsd'),
(N'app_7', N'pet_7', NULL, 0, N'2023-04-26 17:10:55.563', N'2023-05-30 17:10:00.000', N'dsfsfsdfsbxcvxcxc'),
(N'app_8', N'pet_8', NULL, 0, N'2023-05-07 10:14:25.843', N'2023-05-07 10:14:00.000', N'Tiêm phòng tổng quát'),
(N'app_9', N'pet_9', N'doctor', 1, N'2023-05-07 10:14:41.073', N'2023-05-15 10:14:00.000', N'Tiêm phòng dại'),
(N'app_10', N'pet_4', NULL, 0, N'2023-05-07 10:15:14.540', N'2023-05-02 10:15:00.000', NULL),
(N'app_11', N'pet_6', NULL, 0, N'2023-05-07 10:16:18.607', N'2023-05-05 10:15:00.000', N'Tiêm phòng chống cảm cúm + bệnh đường ruột');


Insert into vaccine_lot (lot_number, vaccine_code, production_date, expiration_date, rival_date, total_amount, remain_amount, dose_unit, import_price, sale_price, tax, publisher, note)
values
(N'1249850', N'VC001', N'2022-04-12', N'2024-10-18', N'2023-02-06', N'500', N'200', N'0', N'30', N'50', N'7', N'Dinh Huy', N'aissss'),
(N'1249851', N'VC002', N'2023-03-27', N'2023-05-07', N'2023-05-05', N'3', N'3', N'0', N'300', N'350', N'6', N'HUY HUY HUY', N'abc'),
(N'2987340', N'VC002', N'2023-04-23', N'2023-05-11', N'2023-04-25', N'23', N'23', N'0', N'300', N'350', N'6', N'HUY HUY HUY', N'test add'),
(N'3874013', N'VC012', N'2022-08-02', N'2023-12-05', N'2022-09-05', N'300', N'236', N'1', N'120', N'150', N'5', N'HuyDepChai', N'koko'),
(N'8375910', N'VC003', N'2021-06-04', N'2024-04-06', N'2023-04-18', N'300', N'123', N'0', N'250', N'290', N'12', N'Truc My', N'hehe'),
(N'8750193', N'VC005', N'2022-08-02', N'2026-05-12', N'2023-04-18', N'350', N'124', N'1', N'100', N'130', N'7', N'My Cao', N'abc'),
(N'9835011', N'VC009', N'2021-09-09', N'2026-05-12', N'2023-02-02', N'450', N'294', N'0', N'150', N'160', N'0', N'Tung', N'bin');

Insert into bill (bill_id, client_username, init_date, total_cost, description)
values
(N'BILL002', N'toilakhachhang123', N'2023-05-03 17:25:52.510', N'1210', null),
(N'BILL003', N'toilakhachhang123', N'2023-05-03 17:27:21.047', N'2030', null),
(N'BILL004', N'toilakhachhang2', N'2023-05-03 17:29:26.323', N'960', null),
(N'BILL006', N'toilakhachhang1', N'2023-05-03 17:49:25.627', N'50', N'test ghi chu ');

Insert into bill_vaccine (bill_id, vaccine_lot_number, amount, cost)
values
(N'BILL002', N'1249850', N'1', N'50'),
(N'BILL002', N'8375910', N'4', N'1160'),
(N'BILL003', N'9835011', N'4', N'640'),
(N'BILL003', N'1249850', N'6', N'300'),
(N'BILL003', N'9835011', N'4', N'640'),
(N'BILL003', N'1249850', N'9', N'450'),
(N'BILL004', N'8750193', N'7', N'910'),
(N'BILL004', N'1249850', N'1', N'50'),
(N'BILL006', N'1249850', N'1', N'50');

SET IDENTITY_INSERT pet_vaccine ON;
INSERT INTO pet_vaccine (record_id, pet_id, vaccine_code, state, dose_order, vaccine_date)
VALUES 
(14, N'pet_9', N'VC001', 0, 1, N'2023-05-07'),
(15, N'pet_9', N'VC001', 0, 2, N'2023-05-07'),
(16, N'pet_9', N'VC008', 0, 1, N'2023-05-07'),
(17, N'pet_9', N'VC010', 0, 1, N'2023-05-07'),
(18, N'pet_9', N'VC010', 1, 2, N'2023-05-07'),
(21, N'pet_6', N'VC001', 0, 1, N'2023-05-07'),
(22, N'pet_3', N'VC001', 1, 1, N'2023-05-07'),
(23, N'pet_3', N'VC001', 0, 2, N'2023-06-08'),
(24, N'pet_3', N'VC006', 1, 1, N'2023-05-07');
