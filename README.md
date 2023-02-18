# POS System API
A POS system can scan member QR code and coupon QR code. And pass the purchased item list, total amount and scanned qr member code and coupon to Point System. Coupons are limited quantity and each scanning coupon code needs to check available remaining coupons quantity  handle multiple users scanning the same coupon at the same time. If the coupon is limited to 30 qty, only the first 30 members can use the coupon.
## A POS  is capable of 
- Scan QR Code
- Member QR Code
- Coupon QR Code for discount
- Check Coupon available qty is valid. (Use Redis Cache for qty)
- Pass to point system api for calculate point with following information
 - Member Code
 - Coupon Code (optional)
 - Receipt Number
 - Item list purchased
 - Item list type include
 - Alcohol or Non Alcohol
 - Price
 - Qty
 - Total Price
		

# Point System API

## Point system calculates member earning points based on incoming from POS API.

Point System API is capable of
Calculate point based on POS API incoming request’s item price only for Non Alcohol item. (Eg : Total Non Alcohol item’s purchase price $100 = 10 points)
Add point to member which incoming from POS API’s member code

# CMS API

## CMS can view member lists, report and can create coupons for discounts which will appear on member mobile apps and reports.

CMS API is capable of
- Cms user login with email and password
- Single login which means User A login at Device A and User A login at Device B, Device A will automatically logout.
 - Create, Update, List coupon with following fields
	- Coupon Name
	- Coupon available Start DateTime, End DateTime
	- Discount amount
	- Available Quantity
	- QR code
	- QR code need to generate for each coupon
	- Member list which include following
	- Name
	- Mobile number
	- Total Points
	- Total purchased amount

## Report
Report Coupon used include following column
-	Coupon Name 
-	Coupon Code 
-	Member Code
-	Receipt Number 
-	Used Date
-	Report Exchange point include following column
-	Member Code 
-	Point exchange
-	Exchange coupon amount
-	Remaining point
-	must use report for SQL Query for Report

# Mobile API

Mobile API is for the customer application, members can see their points, total purchased history, available coupon for discount and exchange coupon using.
show member QR code to scan at the cashier for the POS system.

-	Register Member via mobile number verification with OTP code
	[Optional] No need to send sms or email really, just save otp code in the database and verify using otp.
-	Single login which means User A login at Device A and User A login at Device B, Device A will automatically logout.
-	Member QR Code needs to be displayed with a QR to use at POS systems to scan member QR code.
-	Members can see the purchase history list.
-	Members can see total points and use redis cache for quick response points.
-	Members can exchange points to get coupons like $5, $10 (eg : 500 points => $5 coupon).
-	Exchange point is only belong to exchange members
-	Members can see available limited coupons with quantity. (optional use realtime DB for qty eg: firebase realtime DB) and exchange coupon.

# System Architecture Diagram
- https://drive.google.com/file/d/1aVRD3D73Bd-l2D8LYDOUTkPXc4kmhfwG/view