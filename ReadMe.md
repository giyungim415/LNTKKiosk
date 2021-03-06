# LotteNaldsTouchKing Kiosk (이하 LNTKK)


 ## 1. LTNK에 관하여
* 커스터마이징 햄버거를 판매하는 식당에서 사용가능한 프로그램이다.
* 고객용 키오스크와 관리자용 관리 시스템으로 구성되어 있다. 
* 고객은 키오스크를 사용하여 전산으로 주문 정보를 주방에 전달할 수 있다.
* 관리자는 관리 시스템을 사용하여 전산으로 주문 관리, 자재 관리를 할 수 있다.



## 2. 기능목록

#### 관리자 기능

##### 1. 주문관리
- 키오스크에서 넘어온 고객의 주문정보들을 실시간으로 볼 수 있습니다.
![Order Management](Documents/OrderManagement.png)

- 주방에서 주문을 확인하고 준비 중인 주문이 완료되면 준비 완료로 변경해주는 기능을 수행합니다.
 ![Chef](Documents/Chef.png)

##### 2. 상품관리  
- 좌측 상단의 버튼을 통해 상품들을 분류하여 볼 수 있습니다.
![Product Management](Documents/ProductManagement.png)

- 상품의 등록, 수정, 삭제 기능을 수행합니다.
![Product Insert](Documents/ProductInsert.png)
![Product Update](Documents/ProductUpdate.png)

- 우측 상단의 레시피관리 버튼을 통해 레시피의 등록, 수정, 삭제 기능을 수행합니다.
 ![Recipe Management](Documents/RecipeManagement.png)

##### 3. 매출조회
- 상품의 매출 정보를 그래프와 함께 볼 수 있습니다.
- 또한 특정 상품들을 선택하고 조건(연도별, 월별등)을 설정하여 비교하여 볼 수 있습니다.
![Revenue Management](Documents/RevenueManagement.png)

##### 4. 재료관리
- 매장에 있는 재료들의 재고를 관리합니다
![Stock Management](Documents/StockManagement.png)

- 우측 상단의 식재료관리 버튼으로 식재료를 관리합니다.
 ![Grocery Management](Documents/GroceryManagement.png)
#### 사용자 기능
1. 장바구니에 담기   
   <p align="center"><img src="https://user-images.githubusercontent.com/63761587/89606787-e323c180-d8ab-11ea-9e8c-c3856c0709cc.png" height="60%" width="30%"></img>　　<img src="https://user-images.githubusercontent.com/63761587/89606821-f767be80-d8ab-11ea-8893-1d0a2f7f17fb.png" height="60%" width="30%"></img> </p>
   
2. 커스터마이징       
   <p align="center"><img src="https://user-images.githubusercontent.com/63761587/89606836-02baea00-d8ac-11ea-9e08-4a9147580d32.png" height="60%" width="30%"></img> <img src="https://user-images.githubusercontent.com/63761587/89614990-8aaaef00-d8c0-11ea-9e25-080de3c2469f.png" height="60%" width="30%"></img> </p>

 
   

## 3. 행위 목록
#### 관리자
- 주문 정보를 관리한다.
- 기존 메뉴, 레시피, 식자재를 수정 및 삭제한다.
- 새로운 메뉴, 레시피, 식자재를 추가한다.
- 분기별 매출 실적을 확인한다.

#### 사용자
- 메뉴를 장바구니에 담는다.
- 장바구니에 담긴 메뉴들을 확인한다
- 세트 구성 및 햄버거 재료를 커스터마이징한다.

## 4. 사용 기술
### 언어
 - C# 3.0+
### 프레임워크
 - .Net FrameWork 4.8+
 - WinForm
 - Entity FrameWork 6.2+
### 3rd Party Control
 - Devexpress WinForm
### 데이터베이스
 - MSSQL Server 2019



## 5. 데이터베이스 스키마
   <p align="center"><img src="https://user-images.githubusercontent.com/63761587/89612643-4701b680-d8bb-11ea-82d2-299c18f5b421.png"></img></p>




## 6. Point Of Interest

### 프로그램의 병목현상
 >#### 증상   
 >메뉴를 띄우는 화면에서 그림들이 다 로딩되기까지 시간이 많이 걸림
 >#### 원인   
 >DB에는 이미지가 bytearray로 저장되어있는데, 프로그램에서는 이미지가 img 형식이기 때문에, bytearray를 img로 바꾸어주지 않아 로딩시간이 많이 걸렸음.
 >#### 결과   
 >JetBrains라는 회사에서 만든 DotTrace라는 프로그램을 사용해서 정확히 어떤 부분에서 시간이 오래 걸리는지를 확인 할 수 있었음. 프로그램에서 이미지를 img 형식 대신 bytearray를 사용하게 해서 병목지점을 생략했음      
   
### 폼들 사이에 정보를 주고 받는 데서 생기는 문제
 >#### 증상    
 >이전 폼에서 생성한 정보를 최종 폼까지 전달하지 못함   
 >#### 상황      
 >장바구니에 담긴 상품 정보, 고객들이 커스터마이징 단계에서 변경한 세트 구성 및 버거 재료에 관한 정보를 결제가 끝날 때까지 갖고 있다가 최종적으로 DB에 저장까지 해야함    
 >#### 결과     
 >해결 방법으로는 이벤트 이용하는 법, 인터페이스를 사용하는 법, singleton 패턴를 사용하는 방법이 있었음. 이 중에서 가장 간단히 문제를 해결할 수 있는 방법인 singleton 패턴을 사용해서 문제를 해결했음   

### 데이터로드의 속도문제
 >#### 증상
  >관리자 폼의 상품관리 탭에서 상품에 대한 데이터소스를 여러개 가져올 때 속도저하 현상 발생
 >#### 원인
  >상품 테이블의 속성중에 이미지가 있어 데이터로드시 속도 저하발생
 >#### 결과
  >그리드 뷰에서는 이미지속성이 필요하지 않아 그리드뷰에서 필요한 속성만 가진 클래스를 만들고 필요한 속성만 선택하는 쿼리를 작성하여 해결
  >![Product Partial Class](Documents/ProductPartialClass.PNG)
  >![Product Partial](Documents/ProductPartial.PNG)
