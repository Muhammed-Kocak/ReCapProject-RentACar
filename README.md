# Rent A Car Project * Araç Kiralama Projesi

## Build With

<p><a href="https://docs.microsoft.com/en-us/dotnet/csharp/" rel="nofollow"><img src="https://camo.githubusercontent.com/dd433625a6e00049c26f08143705ff9e32d5da44f503f1be133664b11e37e34b/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f432532332d3233393132303f7374796c653d666f722d7468652d6261646765266c6f676f3d632d7368617270266c6f676f436f6c6f723d7768697465" alt="C-Sharp" data-canonical-src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&amp;logo=c-sharp&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://dotnet.microsoft.com/apps/aspnet" rel="nofollow"><img src="https://camo.githubusercontent.com/d2eedef86b5c7700ce36b271700d22a225ed80deb882f1bc627b0b1d3543dd3f/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4153502e4e45542d3543324439313f7374796c653d666f722d7468652d6261646765266c6f676f3d2e6e6574266c6f676f436f6c6f723d7768697465" alt="Asp-net" data-canonical-src="https://img.shields.io/badge/ASP.NET-5C2D91?style=for-the-badge&amp;logo=.net&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://www.microsoft.com/en-us/sql-server/sql-server-2019?rtc=2" rel="nofollow"><img src="https://camo.githubusercontent.com/4c4e18333e9f48e9f6f4190e08dee3957c75b531a2bb78e9bfe33cbdcf99cdd4/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4d5353514c2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6d6963726f736f66742d73716c2d736572766572266c6f676f436f6c6f723d7768697465" alt="MSSQL" data-canonical-src="https://img.shields.io/badge/MSSQL-004880?style=for-the-badge&amp;logo=microsoft-sql-server&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://docs.microsoft.com/en-us/ef/" rel="nofollow"><img src="https://camo.githubusercontent.com/1d5fe1015065a89592443eb419d5974655ffbe17c2d9a1e51c73bd0ad9a357ba/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f456e746974792532304672616d65776f726b2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Entity-Framework" data-canonical-src="https://img.shields.io/badge/Entity%20Framework-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://autofac.org/" rel="nofollow"><img src="https://camo.githubusercontent.com/660a4e0e53571f8f593a56df74573cb8f09777268a87305057363a9b38a3dd59/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4175746f6661632d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Autofac" data-canonical-src="https://img.shields.io/badge/Autofac-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a>
<a href="https://fluentvalidation.net/" rel="nofollow"><img src="https://camo.githubusercontent.com/6deba73d71845daec484b10b754dc0c648cdd13fb24480c38e52becf608f215f/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f466c75656e7425323056616c69646174696f6e2d3030343838303f7374796c653d666f722d7468652d6261646765266c6f676f3d6e75676574266c6f676f436f6c6f723d7768697465" alt="Fluent-Validation" data-canonical-src="https://img.shields.io/badge/Fluent%20Validation-004880?style=for-the-badge&amp;logo=nuget&amp;logoColor=white" style="max-width:100%;"></a></p>


<details>
 <summary>Specifications</summary>
  
  + Car Operations
    + Get all cars
    + Get a single car (With filtering option)
    + Add a new car
    + Edit a car
    + Delete a car
  
  + Car Image Operations
    + Get a car image
    + Get all image
    + Add (Upload) a New Car Image
    + Edit a car image
    + Delete a car image
  
  + Brands Operations
    + Get all brands
    + Get a brand
    + Add a brand
    + Edit a brand
    + Delete a brand
  
  + Colors Operations
    + Get all colors
    + Get a color
    + Add a color
    + Edit a color
    + Delete a color
  
  + Car Image Operations
    + Get a car image
    + Get all image
    + Add (Upload) a New Car Image
    + Edit a car image
    + Delete a car image
  
  + Customer Operations
    + Get all customer
    + Get single customer

    ### Will be added new ..
    + Add a customer
    + Edit a customer
    + Delete a customer
  
  + Rental Operations
    + Get all rentals
    + Get single rental
    + Check car is rentable
    + Check findeks score sufficiency
          
    ### Will be added new ..
    + Add a rental
    + Edit a rental
    + Delete a rental
  
  + Users Operations
    + Get all users
    + Get a user
    + Get user detail by mail
      
    ### Will be added new ..
    + Update user detail
    + Add a user
    + Edit a user
    + Delete a user
    
</details>
<details>
 <summary>Authentication</summary>
 
### Requests are authenticated using the Authorization header and value Bearer {{token}}. with a valid JWT.

+ Authentication Strategy : JWT
  + JWT Expiration : 10 Minutes For Testing Api
  
+ Registration
  + User can register as a "Admin" or simply "User"
  + Password Salt
  + Password Hash
  + Token includes : "id", "email", "name" and "roles"
  
+ Login
  + User can login with "email" and "password"
  + Everytime a user login, new Token are sent to to client
  
+ Operations
  + Login
  + Register new user
  + Check user exist
  + Check user is authenticated

+ Operation Claim
  + Get a operation claim
  + Get all operation claim
  
  ### Will be added new ..
  + Add a operation claim
  + Edit a operation claim
  + Delete a operation claim

### Will be added new ..
+ Credit Card Operations (Test)
  + Get a credit card
  + Get all users (Searching credit card by customer)
  + Add a credit card
  + Delete a credit card

+ Payment Operation (Test)
  + Payment (Fake)

+ Findeks Operations (Test)
  + Get all findeks
  + Get a findeks
  + Searching findeks by customer
  + Calculate findeks score (Fake)

</details>
<details>
  <summary>Layers</summary>

## Business
 > Business Layer created to process or control the incoming information according to the required conditions.


## Core
 > Core layer containing various particles independent of the project.


## DataAccess
 > Data Access Layer created to perform database CRUD operations.


## Entities
 > Entities Layer created for database tables.
 
 
## WebAPI
 > Web API Layer that opens the business layer to the internet.

</details>

<details>
  <summary>Models</summary>
  
### Cars

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| CarId  | Int  | False  |   |
| BrandId  | int  | False  |   |
| ColorId  | int  | False  |   |
| ModelYear  | int  | False  |   |
| DailyPrice  | int  | False  |   |
| Description  | nvarchar(MAX)  | False  |   |
| MinFindeksScore  | smallint  | True  | ((0))  |

### Brands

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| BrandId  | int  | False  |   |
| BrandName  | nvarchar(MAX)  | False  |   |

### Colors

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| ColorId  | int  | False  |   |
| ColorName  | nvarchar(MAX)  | False  |   |

### Car Images

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| CarImageId  | int  | False  |   |
| CarId  | int  | False  |   |
| ImagePath  | nvarchar(MAX)  | False  |   |
| Date  | datetime  | False  |   |

### Credit Cards

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| CreditsCardsId  | int  | False  |   |
| CustomerId  | int  | False  |   |
| NameSurname  | nvarchar(100)  | False  |   |
| CardNumber  | nvarchar(25)  | False  |   |
| ExpMonth  | tinyint  | False  |   |
| ExpYear  | tinyint  | False  |   |
| Cvc  | nvarchar(3)  | False  |   |
| CardType  | nvarchar(20)  | False  |   |

### Customers

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| CustomerId  | int  | False  |   |
| UserId  | int  | False  |   |
| CompanyName  | nvarchar(MAX)  | False  |   |

### Findeks

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| FindeksId  | int  | False  |   |
| CustomerId  | int  | False  |   |
| [NationalIdentity]  | nvarchar(50)  | False  |   |
| Score  | smallint  | False  |   |

### Operation Claims

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| OperationClaimId  | int  | False  |   |
| Name  | nvarchar(MAX)  | False  |   |

### User Operation Claims

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| UserOperationClaimId  | int  | False  |   |
| UserId  | int  | False  |   |
| OperationClaimId  | int  | False  |   |
  
### Users

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| UserId  | int  | False  |   |
| FirstName  | nvarchar(MAX)  | False  |   |
| LastName  | nvarchar(MAX)  | False  |   |
| Email  | nvarchar(MAX)  | False  |   |
| PasswordSalt  | varbinary(MAX)  | False  |   |
| PasswordHash  | varbinary(MAX)  | False  |   |
| Status  | bit  | False  |   |

### Payments

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| PaymentId  | int  | False  |   |
| Amount  | money  | False  |   |

### Rentals

| Name  | Data Type | Allow Nulls | Default |
| ------------- | ------------- | ------------- | ------------- |
| RentalId  | int  | False  |   |
| CarId  | int  | False  |   |
| CustomerId  | int  | False  |   |
| RentDate  | date  | False  |   |
| RentDate  | date  | True  |   |


</details>

## Finally..

> It is a cross platform project.

> It has 'Business', 'Data Access', 'Core', 'Entities' layers and is designed in accordance with the 'SOLID' principles.

> 'Autofac' has been injected as 'IoC'.

> 'Fluent Validation' is in use for 'Validation' controls.

> Written 'MiddlewareExceptionExtension' for 'Exception'.


## Contact

>  [Muhammed Koçak Linkedin](https://www.linkedin.com/in/muhammed-koçak-387960208/) 
>  [For other projects on GitHub](https://github.com/Muhammed-Kocak) 
>  [Muhammed Koçak İnstagram](https://www.instagram.com/sky._.cry/) 
>  [Muhammed Koçak Facebook](https://www.facebook.com/muhammed.kocak1) 

<p><a href="https://github.com/Muhammed-Kocak/recap-frontend/graphs/contributors"><img src="https://camo.githubusercontent.com/cdfc5f2c10e5cea0a9410ec0a43614e421c9e9446f5653dfa6b8516b82b92d71/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f636f6e7472696275746f72732f61686d65742d636574696e6b6179612f526543617050726f6a6563742d46726f6e74656e642e7376673f7374796c653d666f722d7468652d6261646765" alt="Contributors" data-canonical-src="https://img.shields.io/github/contributors/ahmet-cetinkaya/ReCapProject-Frontend.svg?style=for-the-badge" style="max-width:100%;">
</a>
<a href="https://github.com/Muhammed-Kocak/recap-frontend/issues"><img src="https://camo.githubusercontent.com/14cd91b0d5f73b43b214fee43148630293a892884762222e98246c6eb4b29217/68747470733a2f2f696d672e736869656c64732e696f2f6769746875622f6973737565732f61686d65742d636574696e6b6179612f526543617050726f6a6563742d46726f6e74656e642e7376673f7374796c653d666f722d7468652d6261646765" alt="Issues" data-canonical-src="https://img.shields.io/github/issues/ahmet-cetinkaya/ReCapProject-Frontend.svg?style=for-the-badge" style="max-width:100%;">
</a>
<a href="https://www.linkedin.com/in/muhammed-koçak-387960208/" rel="nofollow"><img src="https://camo.githubusercontent.com/a80d00f23720d0bc9f55481cfcd77ab79e141606829cf16ec43f8cacc7741e46/68747470733a2f2f696d672e736869656c64732e696f2f62616467652f4c696e6b6564496e2d3030373742353f7374796c653d666f722d7468652d6261646765266c6f676f3d6c696e6b6564696e266c6f676f436f6c6f723d7768697465" alt="LinkedIn" data-canonical-src="https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&amp;logo=linkedin&amp;logoColor=white" style="max-width:100%;">
</a></p>

<p align="start">
    Frontend of <a href="https://github.com/Muhammed-Kocak/ReCapProject-RentACar">ReCapProject</a> with Angular.
    <br>
    <br>
    <a href="https://github.com/Muhammed-Kocak/recap-frontend/issues">Report Bug</a>
    ·
    <a href="https://github.com/Muhammed-Kocak/recap-frontend/issues">Request Feature</a>
</p>





Don't forget to mention my mistakes and give stars if you like it :)
---------------------------
Hatalarımdan bahsetmeyi ve beğenirsen yıldız vermeyi unutma :)

