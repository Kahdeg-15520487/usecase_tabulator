// Name Đăng ký tài khoản - Account Registration
// Purpose	Tạo tài khoản cho người dùng
// Actor	Khách hàng - User
// PreCond	Không có
// PostCond	Không có
// MainFlow
// 	1. Người dùng nhập các thông tin cơ bản dựa trên mẫu có sẵn
// 	2. Hệ thống xác nhận các thông tin đúng định dạng
// 	3. Hệ thống tạo ra 1 tài khoản cho người dùng
// 	4. Hệ thống gửi email xác thực đăng ký cho người dùng
// 	5. Người dùng xác thực email
// 	6. Hệ thống thực hiện active tài khoản
// AltFlow
// 	5.a Người dùng không nhận được email xác thực
// 	5.a1 Hệ thống gửi lại email xác thực đăng ký cho người dùng
// 	5.a2 Người dùng xác thực email
// 	Use case tiếp tục bước 6
// 	2.b Người dùng nhập các thông tin cơ bản sai hoặc thiếu so với mẫu có sẵn.
// 	2.b1 Hệ thống thông báo cho người dùng về các mục bị nhập sai hoặc thiếu.
// 	2.b2 Người dùng nhập đúng các thông tin cơ bản dựa trên mẫu có sẵn
// 	Use case tiếp tục bước 3
// Exception
// 	2.c Người dùng nhập email đã có sẵn trong hệ thống
// 	2.c1 Hệ thống thông báo cho người dùng biết email này đã được đăng ký
// 	2.c2 Hệ thống hỏi người dùng liệu có muốn đăng nhập hay không
// 	2.c3 Người dùng lựa chọn có
// 	Use case tiếp tục Use Case |UC đăng nhập|
// OtherEvent	Không có
// Markup
// User -> System: Thông tin đăng ký
// note right of System: Kiểm tra tính đúng đắn thông tin đăng ký
// System --> User: Kết quả kiểm tra
// alt Thông tin đăng ký đúng
// System -> Database: Tạo tài khoản với thông tin đăng ký
// else Thông tin đăng ký sai
// System --> User: Hiển thị lỗi
// end

// System --> User: Gửi email xác thực đăng ký
// User -> System: Xác thực email
// note right of System: Thực hiện active tài khoản
// =============
// Name	Quên mật khẩu - Forgot password
// Purpose	Tạo lại mật khẩu cho người dùng
// Actor	User
// PreCond	Không có
// PostCond	Người dùng có được mật khẩu mới để đăng nhập
// MainFlow
// 	1. Người dùng nhập vào email đã sử dụng để đăng ký tài khoản
// 	2. Hệ thống gửi email thông báo về việc reset password cùng 1 liên kết tới trang reset password
// 	3. Người dùng xem email
// 	4. Người dùng truy cập trang reset password
// 	5. Người dùng nhập mật khẩu mới
// 	6. Hệ thống tiến hành hash và salt mật khẩu mới và lưu vào csdl
// AltFlow
// 	3.a Người dùng không nhận được email reset password
// 	Use case tiếp tục bước 1
// Exception
// 	1.b Người dùng nhập vào email không tồn tại trong hệ thống
// 	1.b1 Hệ thống thông báo email không tồn tại trong hệ thống
// 	Use case dừng lại
// OtherEvent Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Nhập email đã sử dụng để đăng ký tài khoản
// note right of s: Kiểm tra email đã tồn tại trong hệ thống hay chưa
// alt Email đã tồn tại
// s --> u: Email chứa liên kết tới trang reset password
// note right of u: Người dùng xem email và truy cập vào liên kết tới trang reset password
// u -> s: Người dùng nhập mật khẩu mới
// note right of s: Thực hiện hash và salt mật khẩu mới
// s -> d: Cập nhật mật khẩu mới
// s --> u: Thông báo người dùng rằng mật khẩu đã được đổi thành mật khẩu mới
// else Email không tồn tại
// s --> u: Thông báo người dùng rằng email không tồn tại
// end
// =============
// Name	Chỉnh sửa thông tin cá nhân
// Purpose	User chỉnh sửa thông tin của mình
// Actor	User
// PreCond	User đã đăng nhập thành công
// PostCond	User thay đổi thông tin của mình
// MainFlow
// 	1. User thực hiện thay đổi thông tin của mình trên mẫu
// 	2. Hệ thống xác nhận các thông tin đã được thay đổi đúng định dạng
// 	3. Hệ thống lưu trữ thay đổi vào Cơ sở dữ liệu
// Exception
// 	2a. Thông tin sai định dạng
// 	2a1. Hệ thống thông báo User về lỗi thông tin
// 	Usecase tiếp tục bước 1
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Chỉnh sửa thông tin cá nhân
// note right of s: Kiểm tra thông tin đúng định dạng
// alt Đúng định dạng
// s -> d: Lưu trữ thông tin được chỉnh sửa
// else Sai định dạng
// s --> u: Thông báo lỗi
// end
// =============
// Name	Tra cứu sản phẩm
// Purpose	User tra cứu sản phẩm trên hệ thống
// Actor	User
// PreCond	Không có
// PostCond	Hiển thị danh sách tra cứu sản phẩm với yêu cầu tra cứu của User
// MainFlow
// 	1. User nhập yêu cầu tra cứu vào Hệ thống
// 	2. Hệ thống thực hiện truy xuất Cơ sở dữ liệu dựa trên yêu cầu tra cứu
// 	3. Hệ thống trả về kết quả tra cứu sản phẩm	
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Yêu cầu tra cứu sản phẩm
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Kết quả tra cứu sản phẩm
// =============
// Name	Xem thông tin sản phẩm
// Purpose	User xem thông tin chi tiết của sản phẩm
// Actor	User
// PreCond Không có
// PostCond	Không có
// MainFlow
// 	1. User chọn vào sản phẩm muốn xem
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy chi tiết sản phẩm được chọn
// 	3. Hệ thống hiển thị chi tiết sản phẩm được chọn
// Exception	Không có
// OtherEvent Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem chi tiết sản phẩm
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Chi tiết sản phẩm
// =============//
// Name	Xem Thông tin đơn hàng
// Purpose	User xem thông tin đơn hàng đã thanh toán
// Actor	User
// PreCond User đã đăng nhập thành công, User có đơn hàng đã thanh toán
// PostCond	Không có
// MainFlow
// 	1. User chọn đơn hàng mình muốn xem
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy chi tiết đơn hàng được chọn
// 	3. Hệ thống hiển thị chi tiết đơn hàng được chọn
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem thông tin đơn hàng
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Thông tin đơn hàng
// =============
// Name	Xem danh sách sản phẩm yêu thích
// Purpose	User xem danh sách các sản phẩm mình đã yêu thích
// Actor	User
// PreCond	User đã đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User yêu cầu danh sách sản phẩm yêu thích
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy danh sách sản phẩm yêu thích
// 	3. Hệ thống hiển thị danh sách sản phẩm yêu thích
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem danh sách sản phẩm yêu thích
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Danh sách sản phẩm yêu thích
// =============
// Name	Xem thông tin lịch sử giao hàng
// Purpose	User xem thông tin lịch sử giao hàng của đơn hàng đã thanh toán
// Actor	User
// PreCond User đã đăng nhập thành công, User có đơn hàng đã thanh toán
// PostCond	Không có
// MainFlow
// 	1. User chọn đơn hàng mình muốn xem lịch sử giao hàng
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy lịch sử giao hàng của đơn hàng được chọn
// 	3. Hệ thống hiển thị lịch sử giao hàng
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem thông tin lịch sử giao hàng
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Thông tin lịch sử giao hàng
// =============
// Name	Xem thông báo (Notification)
// Purpose	User xem thông báo nhận được từ hệ thống
// Actor	User
// PreCond	User đã đăng nhập
// PostCond	Không có
// MainFlow
// 	1. User truy cập danh sách thông báo
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy danh sách thông báo của User
// 	3. Hệ thống hiển thị danh sách thông báo
// 	4. User chọn thông báo để xem nội dung thông báo
// Exception	Không có
// OtherEvent Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem thông báo
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Danh sách thông báo
// =============
// Name	Xem lịch sử giao dịch
// Purpose	User xem thông tin lịch sử giao dịch của mình
// Actor	User
// PreCond User đã đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User truy cập lịch sử giao dịch
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy lịch sử giao dịch của User
// 	3. Hệ thống hiển thị lịch sử giao dịch
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem lịch sử giao dịch
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Lịch sử giao dịch
// =============
// Name	Xem danh sách đánh giá sản phẩm
// Purpose	User xem các đánh giá của sản phẩm
// Actor	User
// PreCond	User đang xem chi tiết sản phẩm
// PostCond	Không có
// MainFlow
// 	1. User truy cập đánh giá của sản phẩm
// 	2. Hệ thống truy xuất Cơ sở dữ liệu để lấy danh sách đánh giá của sản phẩm
// 	3. Hệ thống hiển thị danh sách đánh giá sản phẩm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xem danh sách đánh giá sản phẩm
// s -> d: Truy xuất
// d --> s Kết quả truy xuất
// s --> u: Danh sách đánh giá sản phẩm
// =============
// Name	Đặt câu hỏi
// Purpose	User đặt câu hỏi cho Bác sĩ
// Actor	User
// PreCond	User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User đặt câu hỏi
// 	2. Hệ thống lưu trữ câu hỏi vào Cơ sở dữ liệu
// 	3. Hệ thống thông báo câu hỏi đã được đăng tải
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Đặt câu hỏi
// s -> d: Lưu trữ câu hỏi
// s --> u: Thông báo câu hỏi đã được đăng tải
// =============
// Name	Làm khảo sát
// Purpose	User thực hiện khảo sát để nhận được reward và giúp hệ thống hiểu rõ hơn về mình
// Actor	User
// PreCond	User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User yêu cầu thực hiện khảo sát
// 	2. Hệ thống Truy xuất Cơ sở dữ liệu để lấy bộ câu hỏi khảo sát
// 	3. Hệ thống hiển thị bộ câu hỏi khảo sát
// 	4. User trả lời khảo sát
// 	5. Hệ thống lưu kết quả khảo sát vào Cơ sở dữ liệu
// 	6. Hệ thống thực hiện phân loại User dựa trên kết quả khảo sát
// 	7. Hệ thống hiển thị kết quả phân loại của User
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Yêu cầu thực hiện khảo sát
// s -> d: Truy xuất Bộ câu hỏi khảo sát
// s --> u: Hiển thị Khảo sát
// note left of u: Thực hiện khảo sát
// u -> s: Kết quả khảo sát
// s -> d: Lưu trữ kết quả khảo sát
// =============
// Name	Xóa bài viết
// Purpose	User xóa bài viết trên MXH của mình
// Actor	User
// PreCond	User đăng nhập thành công, User có bài viết cần xóa
// PostCond	Không có
// MainFlow
// 	1. User yêu cầu xóa bài viết được chọn
// 	2. Hệ thống đánh dấu bài viết trong Cơ sở dữ liệu là đã bị xóa
// 	3. Hệ thống thông báo bài viết đã được xóa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Xóa bài viết
// s -> d: Đánh dấu bài viết là đã bị xóa
// s --> u: Thông báo bài viết đã bị xóa
// =============
// Name	Thích bài viết
// Purpose	User thích bài viết trên MXH
// Actor	User
// PreCond User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User chọn thích bài viết
// 	2. Hệ thống thêm User vào danh sách User thích bài viết
// 	3. Hệ thống cập nhật danh sách thích bài viết trong Cơ sở dữ liệu
// 	4. Hệ thống hiển thị bài viết đã được thích
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Thích bài viết
// s -> d: Thêm User vào danh sách thích bài viết
// s --> u: Thông báo bài viết đã được thích
// =============
// Name	Chỉnh sửa bài viết
// Purpose	User chỉnh sửa bài viết trên MXH của mình
// Actor	User
// PreCond	User đăng nhập thành công, User có bài viết cần sửa
// PostCond	Không có
// MainFlow
// 	1. User yêu cầu chỉnh sửa bài viết
// 	2. Hệ thống hiển thị mẫu để chỉnh sửa bài viết
// 	3. User thực hiện chỉnh sửa bài viết
// 	4. Hệ thống cập nhật bài viết trong Cơ sở dữ liệu
// 	5. Hệ thống hiển thị bài viết đã được chỉnh sửa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Chỉnh sửa bài viết
// s -> d: Cập nhật bài viết
// s --> u: Thông báo bài viết đã được chỉnh sửa
// =============
// Name	Lưu bài viết
// Purpose	User lưu bài viết trên MXH để xem sau
// Actor	User
// PreCond	User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User chọn lưu bài viết
// 	2. Hệ thống thêm bài viết vào danh sách bài viết được lưu của User
// 	3. Hệ thống cập nhật vào trong Cơ sở dữ liệu
// 	4. Hệ thổng thông báo bài viết đã được lưu
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Lưu bài viết
// s -> d: Thêm bài viết vào danh sách đã lưu
// s --> u: Thông báo bài viết đã được lưu
// =============
// Name	Bình luận bài viết
// Purpose	User bình luận về bài viết trên MXH
// Actor	User
// PreCond	User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User chọn bình luận bài viết
// 	2. Hệ thống hiển thị mẫu để nhập bình luận
// 	3. User thực hiện nhập bình luận về bài viết
// 	4. Hệ thống lưu trữ bình luận vào Cơ sở dữ liệu
// 	5. Hệ thống hiển thị bình luận
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d

// u -> s: Bình luận bài viết
// s -> d: Thêm bình luận vào bài viết
// s --> u: Thông báo bình luận đã được đăng tải
// =============
// Name	Đăng bài viết
// Purpose	User đăng tải bài viết lên MXH
// Actor	User
// PreCond	User đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. User chọn đăng tải bài viết mới
// 	2. Hệ thống hiển thị mẫu để tạo bài viết
// 	3. User thực hiện tạo bài viết mới
// 	4. Hệ thống lưu trữ bài viết mới vào Cơ sở dữ liệu
// 	5. Hệ thống yêu cầu kiểm duyệt cho bài viết
// 	6. Admin thực hiện kiểm duyệt cho bài viết
// 	7. Hệ thống hiển thị bài viết trên MXH
// Exception
// 	6a. Bài viết không thông qua kiểm duyệt
// 	6a1. Hệ thống thông báo cho User rằng bài viết không thông qua kiểm duyệt
// 	Usecase dừng lại
// OtherEvent	Không có
// Markup
// participant User as u
// participant System as s
// participant Database as d
// participant Admin as a

// u -> s: Đăng tải bài viết
// s --> a: Yêu cầu kiểm duyệt bài viết
// note left of a: Kiểm duyệt bài viết
// alt Thông qua kiểm duyệt
// s -> d: Thêm bài viết
// s --> u: Thông báo bài viết đã được đăng tải
// else Không thông qua kiểm duyệt
// s --> u: Thông báo bài viết không thông qua kiểm duyệt
// end
// =============//
// Name	Xóa User
// Purpose	Admin xóa User ra khỏi hệ thống
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn tài khoản User cần xóa và thực hiện yêu cầu xóa
// 	2. Hệ thống đánh dấu tài khoản User trong Cơ sở dữ liệu là đã xóa
// 	3. Hệ thống thông báo đã xóa tài khoản User
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Xóa tài khoản User
// s -> d: Đánh dấu tài khoản là đã xóa
// s --> a: Thông báo đã xóa tài khoản User
// =============//
// Name	Thêm User
// Purpose	Admin tạo tài khoản cho User
// Actor	Admin
// PreCond Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin yêu cầu tạo tài khoản cho User
// 	2. Hệ thống hiển thị mẫu để tạo tài khoản
// 	3. Admin nhập các thông tin tài khoản
// 	4. Hệ thống xác nhận các thông tin đúng định dạng
// 	5. Hệ thống tạo tài khoản cho User dựa theo thông tin đã nhập vào Cơ sở dữ liệu
// Exception
// 	4a. Thông tin được nhập bị sai định dạng
// 	4a1. Hệ thống thông báo cho Admin về lỗi thông tin
// 	Usecase tiếp tục bước 3
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Tạo tài khoản User
// note right of s: Xác nhận thông tin đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Tạo tài khoản cho User
// else Thông tin sai định dạng
// s --> a: Thông báo về lỗi thông tin
// end
// =============//
// Name	Chỉnh sửa thông tin cho User
// Purpose	Admin chỉnh sửa thông tin cho User
// Actor	Admin
// PreCond Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn User cần chỉnh sửa và yêu cầu chỉnh sửa
// 	2. Hệ thống hiển thị mẫu để chỉnh sửa thông tin
// 	3. Admin thực hiện chỉnh sửa thông tin
// 	4. Hệ thống xác nhận thông tin đã chỉnh sửa đúng định dạng
// 	5. Hệ thống cập nhật thông tin đã chỉnh sửa vào Cơ sở dữ liệu
// Exception
// 	4a. Thong tin được nhập bị sai định dạng
// 	4a1. Hệ thống thông báo cho Admin về lỗi thông tin
// 	Usecase tiếp tục bước 3
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Tạo tài khoản User
// note right of s: Xác nhận thông tin đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Tạo tài khoản cho User
// else Thông tin sai định dạng
// s --> a: Thông báo về lỗi thông tin
// end
// =============//
// Name	Tìm kiếm User
// Purpose	Admin tìm kiếm User trong hệ thống
// Actor	Admin
// PreCond Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin yêu cầu tìm kiếm User với thông số
// 	2. Hệ thống truy xuất Cơ sở dữ liệu dựa trên thông số tìm kiếm User
// 	3. Hệ thống hiển thị danh sách User thỏa thông số tìm kiếm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Tìm kiếm User với thông số
// s -> d: Truy xuất Cơ sở dữ liệu với thông số
// d --> s: Kết quả truy xuất
// s --> a: Danh sách User thỏa thông số tìm kiếm
// =============//
// Name	Thêm sản phẩm
// Purpose	Admin thêm sản phẩm vào hệ thống
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin nhập thông tin sản phẩm theo mẫu
// 	2. Hệ thống xác nhận thông tin nhập vào đúng định dạng
// 	3. Hệ thống lưu trữ thông tin sản phẩm mới vào Cơ sở dữ liệu
// Exception
// 	2a. Thông tin sản phẩm nhập bị sai định dạng
// 	2a1. Hệ thống thông báo cho Admin về lỗi thông tin
// 	Usecase tiếp tục bước 1
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Nhập sản phẩm mới
// note right of s: Xác nhận thông tin sản phẩm đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Lưu trữ sản phẩm mới
// else Thông tin sai định dạng
// s --> a: Thông báo lỗi thông tin
// end
// =============
// Name	Xóa sản phẩm
// Purpose	Admin xóa sản phẩm khỏi hệ thống
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn sản phẩm cần xóa và chọn Xóa sản phẩm
// 	2. Hệ thống đánh dấu sản phẩm trong Cơ sở dữ liệu là đã xóa
// 	3. Hệ thống thông báo sản phẩm đã bị xóa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Xóa sản phẩm
// s -> d: Đánh dấu sản phẩm là đã xóa
// s --> a: Thông báo sản phẩm đã bị xóa
// =============
// Name	Cập nhật sản phẩm (Admin)
// Purpose	Admin cập nhật thông tin sản phẩm
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn sản phẩm cần cập nhật thông tin và chọn cập nhật
// 	2. Hệ thống hiển thị mẫu để nhập thông tin cập nhật
// 	3. Admin cập nhật thông tin trên mẫu
// 	4. Hệ thống xác nhận thông tin được cập nhật đúng định dạng
// 	5. Hệ thống cập nhật thông tin vào Cơ sở dữ liệu
// Exception
// 	4a. Thông tin cập nhật sai định dạng
// 	4a1. Hệ thống thông báo cho admin về lỗi thông tin
// 	Usecase tiếp tục bước 3
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Cập nhật sản phẩm
// note right of s: Xác nhận thông tin cập nhật đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Cập nhật thông tin sản phẩm
// else Thông tin sai định dạng
// s --> a: Thông báo lỗi thông tin
// end
// =============
// Name	Tìm kiếm sản phẩm (admin)
// Purpose	Admin tìm kiếm sản phẩm
// Actor	Admin
// PreCond Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin yêu cầu tìm kiếm sản phẩm với thông số
// 	2. Hệ thống truy xuất Cơ sở dữ liệu dựa trên thông số tìm kiếm sản phẩm
// 	3. Hệ thống hiển thị danh sách sản phẩm thỏa thông số tìm kiếm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Tìm kiếm Sản phẩm với thông số
// s -> d: Truy xuất Cơ sở dữ liệu với thông số
// d --> s: Kết quả truy xuất
// s --> a: Danh sách Sản phẩm thỏa thông số tìm kiếm
// =============
// Name	Xóa hoạt chất
// Purpose	Admin xóa hoạt chất khỏi hệ thống
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn hoạt chất cần xóa và chọn Xóa hoạt chất
// 	2. Hệ thống đánh dấu hoạt chất trong Cơ sở dữ liệu là đã xóa
// 	3. Hệ thống thông báo hoạt chất đã bị xóa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Xóa hoạt chất
// s -> d: Đánh dấu hoạt chất là đã xóa
// s --> a: Thông báo hoạt chất đã bị xóa
// =============
// Name	Cập nhật hoạt chất
// Purpose	Admin cập nhật thông tin hoạt chất
// Actor	Admin
// PreCond	Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin chọn hoạt chất cần cập nhật thông tin và chọn cập nhật
// 	2. Hệ thống hiển thị mẫu để nhập thông tin cập nhật
// 	3. Admin cập nhật thông tin trên mẫu
// 	4. Hệ thống xác nhận thông tin được cập nhật đúng định dạng
// 	5. Hệ thống cập nhật thông tin vào Cơ sở dữ liệu
// Exception
// 	4a. Thông tin cập nhật sai định dạng
// 	4a1. Hệ thống thông báo cho admin về lỗi thông tin
// 	Usecase tiếp tục bước 3
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Cập nhật hoạt chất
// note right of s: Xác nhận thông tin cập nhật đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Cập nhật thông tin hoạt chất
// else Thông tin sai định dạng
// s --> a: Thông báo lỗi thông tin
// end
// =============
// Name	Tìm kiếm hoạt chất
// Purpose	Admin tìm kiếm hoạt chất
// Actor	Admin
// PreCond Admin đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Admin yêu cầu tìm kiếm hoạt chất với thông số
// 	2. Hệ thống truy xuất Cơ sở dữ liệu dựa trên thông số tìm kiếm hoạt chất
// 	3. Hệ thống hiển thị danh sách hoạt chất thỏa thông số tìm kiếm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Admin as a

// a -> s: Tìm kiếm hoạt chất với thông số
// s -> d: Truy xuất Cơ sở dữ liệu với thông số
// d --> s: Kết quả truy xuất
// s --> a: Danh sách hoạt chất thỏa thông số tìm kiếm
// =============
// Name	Xóa sản phẩm
// Purpose	Chủ cửa hàng xóa sản phẩm khỏi hệ thống
// Actor	Chủ cửa hàng
// PreCond	Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng chọn sản phẩm cần xóa và chọn Xóa sản phẩm
// 	2. Hệ thống đánh dấu sản phẩm trong Cơ sở dữ liệu là đã xóa
// 	3. Hệ thống thông báo sản phẩm đã bị xóa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Xóa sản phẩm
// s -> d: Đánh dấu sản phẩm là đã xóa
// s --> a: Thông báo sản phẩm đã bị xóa
// =============
// Name	Cập nhật sản phẩm
// Purpose	Chủ cửa hàng cập nhật thông tin sản phẩm
// Actor	Chủ cửa hàng
// PreCond	Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng chọn sản phẩm cần cập nhật thông tin và chọn cập nhật
// 	2. Hệ thống hiển thị mẫu để nhập thông tin cập nhật
// 	3. Chủ cửa hàng cập nhật thông tin trên mẫu
// 	4. Hệ thống xác nhận thông tin được cập nhật đúng định dạng
// 	5. Hệ thống cập nhật thông tin vào Cơ sở dữ liệu
// Exception
// 	4a. Thông tin cập nhật sai định dạng
// 	4a1. Hệ thống thông báo cho Chủ cửa hàng về lỗi thông tin
// 	Usecase tiếp tục bước 3
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Cập nhật sản phẩm
// note right of s: Xác nhận thông tin cập nhật đúng định dạng
// alt Thông tin đúng định dạng
// s -> d: Cập nhật thông tin sản phẩm
// else Thông tin sai định dạng
// s --> a: Thông báo lỗi thông tin
// end
// =============
// Name	Tìm kiếm sản phẩm
// Purpose	Chủ cửa hàng tìm kiếm sản phẩm
// Actor	Chủ cửa hàng
// PreCond Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng yêu cầu tìm kiếm sản phẩm với thông số
// 	2. Hệ thống truy xuất Cơ sở dữ liệu dựa trên thông số tìm kiếm sản phẩm
// 	3. Hệ thống hiển thị danh sách sản phẩm thỏa thông số tìm kiếm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Tìm kiếm sản phẩm với thông số
// s -> d: Truy xuất Cơ sở dữ liệu với thông số
// d --> s: Kết quả truy xuất
// s --> a: Danh sách sản phẩm thỏa thông số tìm kiếm
// =============
// Name	Xóa đơn hàng
// Purpose	Chủ cửa hàng xóa đơn hàng khỏi hệ thống
// Actor	Chủ cửa hàng
// PreCond	Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng chọn đơn hàng cần xóa và chọn Xóa đơn hàng
// 	2. Hệ thống đánh dấu đơn hàng trong Cơ sở dữ liệu là đã xóa
// 	3. Hệ thống thông báo đơn hàng đã bị xóa
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Xóa đơn hàng
// s -> d: Đánh dấu đơn hàng là đã xóa
// s --> a: Thông báo đơn hàng đã bị xóa
// =============
// Name	Duyệt đơn hàng
// Purpose	Chủ cửa hàng duyệt thông tin đơn hàng
// Actor	Chủ cửa hàng
// PreCond	Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng chọn đơn hàng cần duyệt và chọn duyệt đơn
// 	2. Hệ thống cập nhật trạng thái đơn hàng là đã duyệt
// 	3. Hệ thống thông báo cho Chủ cửa hàng đã duyệt đơn hàng
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Yêu cầu duyệt đơn hàng
// s -> d: Lưu trạng thái duyệt của đơn hàng
// s --> a: Thông báo đơn hàng đã duyệt
// =============
// Name	Tìm kiếm đơn hàng
// Purpose	Chủ cửa hàng tìm kiếm đơn hàng
// Actor	Chủ cửa hàng
// PreCond Chủ cửa hàng đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Chủ cửa hàng yêu cầu tìm kiếm đơn hàng với thông số
// 	2. Hệ thống truy xuất Cơ sở dữ liệu dựa trên thông số tìm kiếm đơn hàng
// 	3. Hệ thống hiển thị danh sách đơn hàng thỏa thông số tìm kiếm
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Chủ cửa hàng as a

// a -> s: Tìm kiếm đơn hàng với thông số
// s -> d: Truy xuất Cơ sở dữ liệu với thông số
// d --> s: Kết quả truy xuất
// s --> a: Danh sách đơn hàng thỏa thông số tìm kiếm
// =============
// Name	Xem câu hỏi
// Purpose	Bác sĩ xem danh sách câu hỏi được hỏi
// Actor	Bác sĩ
// PreCond	Bác sĩ đăng nhập thành công
// PostCond	Không có
// MainFlow
// 	1. Bác sĩ yêu cầu xem danh sách câu hỏi
// 	2. Hệ thống truy xuất Cơ sở dữ liệu lấy danh sách câu hỏi được hỏi
// 	3. Hệ thống hiển thị danh sách cho bác sĩ
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Bác sĩ as b

// b -> s: Yêu cầu danh sách câu hỏi
// s -> d: Truy xuất Cơ sở dữ liệu
// d --> s: Kết quả truy xuất
// s --> b: Danh sách câu hỏi được hỏi
// =============
// Name	Trả lời câu hỏi
// Purpose Bác sĩ trả lời câu hỏi
// Actor	Bác sĩ, User
// PreCond	Bác sĩ đăng nhập thành công, Tồn tại câu hỏi để trả lời
// PostCond	Không có
// MainFlow
// 	1. Bác sĩ nhập câu trả lời vào mẫu trả lời
// 	2. Hệ thống lưu trữ câu trả lời vào Cơ sở dữ liệu
// 	3. Hệ thống thông báo cho User đã đặt câu hỏi
// Exception	Không có
// OtherEvent	Không có
// Markup
// participant System as s
// participant Database as d
// participant Bác sĩ as b
// participant User as u

// b -> s: Trả lời câu hỏi
// s -> d: Lưu trữ câu trả lời
// s --> u: Thông báo rằng câu hỏi đã được trả lời
// =============