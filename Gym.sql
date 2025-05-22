CREATE DATABASE Gym;
GO

USE Gym;
GO

-- Bảng memberships – Loại gói tập
CREATE TABLE memberships (
    membership_id INT IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(50),
    duration_days INT,
    price INT
);
GO

-- Bảng members – Hội viên
CREATE TABLE members (
    member_id INT PRIMARY KEY IDENTITY(1,1),
    full_name NVARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    gender NVARCHAR(10),
    date_of_birth DATE,
    join_date DATE DEFAULT CAST(GETDATE() AS DATE),
    membership_id INT,
    training_type VARCHAR(20) CHECK (training_type IN ('Solo', 'PT')),
    trainer_id INT NULL,
    FOREIGN KEY (membership_id) REFERENCES memberships(membership_id),
    FOREIGN KEY (trainer_id) REFERENCES trainers(trainer_id)
);
GO

-- Bảng trainers – Huấn luyện viên
CREATE TABLE trainers(
    trainer_id INT IDENTITY(1,1) PRIMARY KEY,
    full_name NVARCHAR(100),
    phone VARCHAR(20),
    email VARCHAR(100),
    specialization VARCHAR(100)
);
GO

-- Bảng payments – Lịch sử thanh toán
CREATE TABLE payments (
    payment_id INT IDENTITY(1,1) PRIMARY KEY,
    amount INT,
    payment_date DATETIME,
    method NVARCHAR(50) CHECK (method IN (N'Tiền mặt', N'Thẻ tín dụng', N'Chuyển khoản ngân hàng')),
	member_id INT FOREIGN KEY REFERENCES members(member_id)
);
GO

-- Bảng trainer_schedule - Thông tin khung giờ tập (Thứ 2 - Thứ 7)
CREATE TABLE trainer_schedule (
    schedule_id INT IDENTITY(1,1) PRIMARY KEY,
    trainer_id INT NOT NULL,
    day_of_week VARCHAR(10) CHECK (day_of_week IN ('Monday', 'Tuesday', 'Wednesday', 'Thursday', 'Friday', 'Saturday')),
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    FOREIGN KEY (trainer_id) REFERENCES trainers(trainer_id)
);
GO

CREATE TABLE training_sessions (
    session_id INT IDENTITY(1,1) PRIMARY KEY,
    member_id INT FOREIGN KEY REFERENCES members(member_id),
    trainer_id INT FOREIGN KEY REFERENCES trainers(trainer_id),
    session_date DATE,
    start_time TIME,
    end_time TIME
);
GO


-- Bảng products – Quản lý sản phẩm bán ra (nước, whey,...)
CREATE TABLE products (
    product_id INT PRIMARY KEY IDENTITY(1,1),
    name NVARCHAR(100),
    price INT,
    stock_quantity INT,
    description NVARCHAR(255)
);
GO

-- Bảng users – Thông tin đăng nhập người dùng
CREATE TABLE users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password_hash VARCHAR(255) NOT NULL,
);
GO

-- Thêm thông tin cho các gói tập
INSERT INTO memberships (name, duration_days, price)
VALUES 
(N'Gói 1 tháng', 30, 500000),
(N'Gói 3 tháng', 90, 1350000),
(N'Gói 6 tháng', 180, 2500000),
(N'Gói 1 năm', 365, 4500000);

-- Thêm thông tin các huấn luyện viên
INSERT INTO trainers (full_name, phone, email, specialization)
VALUES
(N'Ngô Hoàng Long', '0908765432', 'long.ngo@gym.vn', 'Bodybuilding'),
(N'Vũ Thị Kim Chi', '0912345678', 'chi.vu@gym.vn', 'CrossFit'),
(N'Lâm Thanh Tú', '0909888999', 'tu.lam@gym.vn', 'Zumba'),
(N'Bùi Anh Thư', '0911987654', 'thu.bui@gym.vn', 'Pilates'),
(N'Trịnh Công Danh', '0909000111', 'danh.trinh@gym.vn', 'HIIT'),
(N'Đặng Thị Mai', '0908111222', 'mai.dang@gym.vn', 'Yoga'),
(N'Lê Quốc Hưng', '0911223344', 'hung.le@gym.vn', 'Strength Training'),
(N'Phạm Minh Tâm', '0909222333', 'tam.pham@gym.vn', 'Aerobics'),
(N'Trần Thị Hải Yến', '0912555666', 'yen.tran@gym.vn', 'Dance Fitness'),
(N'Nguyễn Văn Thịnh', '0908333444', 'thinh.nguyen@gym.vn', 'Body Pump'),
(N'Hoàng Thị Lan', '0908777666', 'lan.hoang@gym.vn', 'Kickboxing'),
(N'Lý Gia Bảo', '0912000111', 'bao.ly@gym.vn', 'TRX Suspension'),
(N'Cao Hữu Nghĩa', '0908111000', 'nghia.cao@gym.vn', 'Circuit Training'),
(N'Tống Thị Cẩm Tú', '0912333444', 'tucam.tong@gym.vn', 'Functional Training'),
(N'Võ Nhật Trường', '0909444555', 'truong.vo@gym.vn', 'Stretching & Mobility');

INSERT INTO members (full_name, phone, email, gender, date_of_birth, membership_id, training_type, trainer_id)
VALUES
(N'Phạm Minh Khoa', '0987654321', 'khoa.pm@example.com', N'Nam', '1995-05-20', 1, 'Solo', NULL),
(N'Ngô Thị Hạnh', '0912233445', 'hanh.ngo@example.com', N'Nữ', '1998-03-15', 2, 'PT', 1),
(N'Trần Anh Tú', '0909001122', 'tuanh@example.com', N'Nam', '1990-08-08', 3, 'PT', 3),
(N'Lê Thị Hương', '0909776655', 'huong.le@example.com', N'Nữ', '1996-12-01', 1, 'Solo', NULL),
(N'Nguyễn Hoàng Dương', '0909111444', 'duong.nguyen@example.com', N'Nam', '1994-07-19', 2, 'PT', 5),
(N'Đặng Nhật Quang', '0911556677', 'quang.dang@example.com', N'Nam', '1997-09-11', 1, 'PT', 2),
(N'Trịnh Kim Ngân', '0909222333', 'ngan.trinh@example.com', N'Nữ', '1999-06-30', 3, 'Solo', NULL),
(N'Lâm Gia Huy', '0912888999', 'huy.lam@example.com', N'Nam', '1993-10-10', 2, 'PT', 6),
(N'Bùi Mỹ Linh', '0911998877', 'linh.bui@example.com', N'Nam', '1991-04-22', 1, 'PT', 4),
(N'Đoàn Quốc Tuấn', '0909332211', 'tuan.doan@example.com', N'Nam', '1989-02-14', 2, 'Solo', NULL),
(N'Trần Anh Huy', '0337686257', 'huy.tran@example.com', N'Nam', '2005-02-04', 4, 'Solo', NULL);


INSERT INTO payments (amount, payment_date, method, member_id)
VALUES
(500000, '2024-01-10', N'Tiền mặt', 1),
(1350000, '2024-02-20', N'Thẻ tín dụng', 2),
(2500000, '2024-03-05', N'Chuyển khoản ngân hàng', 3);


INSERT INTO products (name, price, stock_quantity, description)
VALUES
(N'Nước suối 500ml', 10000, 200, N'Nước uống giải khát'),
(N'Whey Protein 1kg', 800000, 50, N'Tăng cơ hiệu quả'),
(N'Khăn tập Gym', 50000, 100, N'Khăn cotton cao cấp'),
(N'Găng tay tập Gym', 120000, 75, N'Bảo vệ tay khi nâng tạ'),
(N'Bình nước thể thao 1L', 90000, 60, N'Bình nhựa cao cấp, giữ nhiệt tốt'),
(N'Thảm Yoga', 250000, 40, N'Chống trượt, êm ái'),
(N'Bột BCAA 300g', 600000, 30, N'Giảm mệt mỏi, phục hồi cơ nhanh'),
(N'Đai lưng tập Gym', 180000, 35, N'Hỗ trợ lưng khi tập nặng'),
(N'Dây kháng lực', 70000, 80, N'Tập luyện linh hoạt và hiệu quả'),
(N'Gel năng lượng', 25000, 120, N'Tăng sức bền khi tập'),
(N'Áo thun tập Gym nam', 150000, 45, N'Chất liệu co giãn, thoáng khí'),
(N'Quần tập Gym nữ', 170000, 50, N'Đẹp, co giãn, thấm hút tốt'),
(N'Pre-Workout 200g', 450000, 25, N'Tăng năng lượng trước buổi tập'),
(N'Thanh protein bar', 30000, 90, N'Ăn nhẹ, nhiều protein'),
(N'Balo thể thao', 220000, 40, N'Đựng đồ tập tiện lợi');



INSERT INTO users (username, password_hash)
VALUES
('admin', '12345');


-- Thứ 2
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(1, 'Monday', '06:00', '08:00'),
(2, 'Monday', '08:00', '10:00'),
(3, 'Monday', '14:00', '16:00'),
(4, 'Monday', '16:00', '18:00');

-- Thứ 3
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(5, 'Tuesday', '06:00', '08:00'),
(6, 'Tuesday', '08:00', '10:00'),
(7, 'Tuesday', '14:00', '16:00'),
(8, 'Tuesday', '16:00', '18:00');

-- Thứ 4
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(9, 'Wednesday', '06:00', '08:00'),
(10, 'Wednesday', '08:00', '10:00'),
(1, 'Wednesday', '14:00', '16:00'),
(2, 'Wednesday', '16:00', '18:00');

-- Thứ 5
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(3, 'Thursday', '06:00', '08:00'),
(4, 'Thursday', '08:00', '10:00'),
(5, 'Thursday', '14:00', '16:00'),
(6, 'Thursday', '16:00', '18:00');

-- Thứ 6
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(7, 'Friday', '06:00', '08:00'),
(8, 'Friday', '08:00', '10:00'),
(9, 'Friday', '14:00', '16:00'),
(10, 'Friday', '16:00', '18:00');

-- Thứ 7
INSERT INTO trainer_schedule (trainer_id, day_of_week, start_time, end_time) VALUES
(1, 'Saturday', '06:00', '08:00'),
(3, 'Saturday', '08:00', '10:00'),
(5, 'Saturday', '14:00', '16:00'),
(7, 'Saturday', '16:00', '18:00');



INSERT INTO training_sessions (member_id, trainer_id, session_date, start_time, end_time)
VALUES
(1, 1, '2025-05-12', '06:00', '08:00'),
(2, 2, '2025-05-12', '08:00', '10:00'),
(3, 3, '2025-05-12', '14:00', '16:00'),
(4, 4, '2025-05-12', '16:00', '18:00'),

(1, 1, '2025-05-13', '06:00', '08:00'),
(2, 2, '2025-05-13', '08:00', '10:00'),
(3, 3, '2025-05-13', '14:00', '16:00'),
(4, 4, '2025-05-13', '16:00', '18:00'),

(1, 1, '2025-05-14', '06:00', '08:00'),
(2, 2, '2025-05-14', '08:00', '10:00'),
(3, 3, '2025-05-14', '14:00', '16:00'),
(4, 4, '2025-05-14', '16:00', '18:00'),

(1, 1, '2025-05-15', '06:00', '08:00'),
(2, 2, '2025-05-15', '08:00', '10:00'),
(3, 3, '2025-05-15', '14:00', '16:00'),
(4, 4, '2025-05-15', '16:00', '18:00'),

(1, 1, '2025-05-16', '06:00', '08:00'),
(2, 2, '2025-05-16', '08:00', '10:00'),
(3, 3, '2025-05-16', '14:00', '16:00'),
(4, 4, '2025-05-16', '16:00', '18:00'),

(1, 1, '2025-05-17', '06:00', '08:00'),
(2, 2, '2025-05-17', '08:00', '10:00'),
(3, 3, '2025-05-17', '14:00', '16:00'),
(4, 4, '2025-05-17', '16:00', '18:00');
