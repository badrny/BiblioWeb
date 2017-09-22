�=
NC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Controllers\HomeController.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Controllers# .
{		 
public

 

class

 
HomeController

 
:

  !

Controller

" ,
{ 
public 

Authentication +
(+ ,
), -
=>. 0
View1 5
(5 6
)6 7
;7 8
public 

Index "
(" #
string# )
name* .
,. /
string0 6
email7 <
,< =
string> D
passwordE M
,M N
stringO U
	cpasswordV _
)_ `
{ 	
if 
( 
name 
== 
null 
) 
{ 
try 
{ 
if 
( 
HttpContext #
.# $
Session$ +
.+ ,
	GetString, 5
(5 6
$str6 <
)< =
.= >
Equals> D
(D E
$strE O
)O P
)P Q
{ 
return 
View #
(# $
)$ %
;% &
} 
return 
RedirectToAction +
(+ ,
$str, <
)< =
;= >
} 
catch 
( 
	Exception  
)  !
{ 
return 
RedirectToAction +
(+ ,
$str, <
)< =
;= >
} 
} 
if 
( 
! 
name 
. 
Equals 
( 
$str '
)' (
||) +
!, -
email- 2
.2 3
Equals3 9
(9 :
$str: L
)L M
||N P
!Q R
passwordR Z
.Z [
Equals[ a
(a b
$strb l
)l m
||n p
!   
	cpassword   
.   
Equals   !
(  ! "
password  " *
)  * +
)  + ,
return  - 3
Ok  4 6
(  6 7
)  7 8
;  8 9
HttpContext!! 
.!! 
Session!! 
.!!  
	SetString!!  )
(!!) *
$str!!* 0
,!!0 1
$str!!2 ;
)!!; <
;!!< =
HttpContext"" 
."" 
Session"" 
.""  
	SetString""  )
("") *
$str""* 0
,""0 1
name""2 6
)""6 7
;""7 8
HttpContext## 
.## 
Session## 
.##  
	SetString##  )
(##) *
$str##* 1
,##1 2
email##3 8
)##8 9
;##9 :
return$$ 
View$$ 
($$ 
)$$ 
;$$ 
}%% 	
public'' 

Contact'' $
(''$ %
)''% &
{(( 	
ViewData)) 
[)) 
$str)) 
])) 
=))  !
$str))" 0
;))0 1
return** 
View** 
(** 
)** 
;** 
}++ 	
public-- 

About-- "
(--" #
)--# $
{.. 	
ViewData// 
[// 
$str// 
]// 
=//  !
$str//" /
;/// 0
return00 
View00 
(00 
)00 
;00 
}11 	
public33 

Error33 "
(33" #
)33# $
=>33% '
View33( ,
(33, -
)33- .
;33. /
public55 

CallInvokeImportItem55 1
(551 2
string552 8

nameofbook559 C
)55C D
=>55E G

(55U V
$str55V h
,55h i

nameofbook55j t
.55t u
Replace55u |
(55| }
$str	55} �
,
55� �
$str
55� �
)
55� �
)
55� �
;
55� �
public77 

CallInvokeSaveItem77 /
(77/ 0
List770 4
<774 5
int775 8
>778 9
	booktypes77: C
,77C D
int77E H
format77I O
,77O P
string77Q W
title77X ]
,77] ^
string77_ e
author77f l
,77l m
DateTime77n v
date77w {
,77{ |
string	77} �
src
77� �
)
77� �
{88 	
var99 
tt99 
=99 
new99 
List99 
<99 
BookType99 &
>99& '
(99' (
)99( )
;99) *
foreach:: 
(:: 
var:: 
item:: 
in::  
	booktypes::! *
)::* +
tt;; 
.;; 
Add;; 
(;; 
new;; 
BookType;; #
{;;$ %
TypeID;;% +
=;;, -
item;;. 2
};;2 3
);;3 4
;;;4 5
var<< 
book<< 
=<< 
new<< 
Book<< 
{<<  !
Title<<" '
=<<( )
title<<* /
,<</ 0
Author<<1 7
=<<8 9
author<<: @
,<<@ A
CoverSrc<<B J
=<<K L
src<<M P
,<<P Q
Date<<R V
=<<W X
date<<Y ]
,<<] ^
Format<<_ e
=<<f g
(<<h i
Book<<i m
.<<m n

BookFormat<<n x
)<<x y
format<<y 
,	<< �
Types
<<� �
=
<<� �
tt
<<� �
}
<<� �
;
<<� �
return== 

(==  !
$str==! 1
,==1 2
JsonConvert==3 >
.==> ?
SerializeObject==? N
(==N O
book==O S
)==S T
)==T U
;==U V
}>> 	
public@@ 

ChangeViewValToTh@@ .
(@@. /
string@@/ 5
displayitem@@6 A
)@@A B
{AA 	
HttpContextCC 
.CC 
SessionCC 
.CC  
	SetStringCC  )
(CC) *
$strCC* 0
,CC0 1
displayitemCC2 =
)CC= >
;CC> ?
returnDD 

(DD  !
$strDD! 1
)DD1 2
;DD2 3
}EE 	
publicGG 

CallInvokeDeleteItemGG 1
(GG1 2
intGG2 5
[GG5 6
]GG6 7
itemskeyGG8 @
)GG@ A
=>GGB D

(GGR S
$strGGS e
,GGe f
itemskeyGGg o
)GGo p
;GGp q
publicII 

CallInvokeIsReadItemII 1
(II1 2
intII2 5
keyII6 9
,II9 :
stringII; A
isreadIIB H
)IIH I
{JJ 	
varKK 
objKK 
=KK 
newKK 
{KK 
KeyKK 
=KK  !
keyKK" %
,KK% &
isReadKK' -
=KK. /
isreadKK0 6
}KK7 8
;KK8 9
returnLL 

(LL  !
$strLL! 3
,LL3 4
objLL5 8
)LL8 9
;LL9 :
}MM 	
publicOO 

CallGetNoteOO (
(OO( )
intOO) ,
keyOO- 0
)OO0 1
=>OO2 4

(OOB C
$strOOC S
,OOS T
keyOOU X
)OOX Y
;OOY Z
}PP 
}QQ �
?C:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Models\Book.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Models# )
{ 
public 

class 
Type 
{		 
public

 
long

 
Key

 
{

 
get

 
;

 
set

 "
;

" #
}

$ %
public 
string 
Label 
{ 
get !
;! "
set# &
;& '
}( )
public 
IList 
< 
BookType 
> 
Types $
{% &
get' *
;* +
set, /
;/ 0
}1 2
}
public 

class 
BookType 
{ 
[ 	

JsonIgnore	 
] 
public 
long 
Key 
{ 
get 
; 
set "
;" #
}$ %
public 
long 
TypeID 
{ 
get  
;  !
set" %
;% &
}' (
public 
long 
BookID 
{ 
get  
;  !
set" %
;% &
}' (
public 
Book 
Book 
{ 
get 
; 
set  #
;# $
}% &
public 
Type 
Type 
{ 
get 
; 
set  #
;# $
}% &
} 
public 

class 
Book 
: 
IMedia 
{ 
public 
enum 

BookFormat 
{   	
Pocket!! 
,!! 
Brochure"" 
,"" 
Degital## 
}$$ 	
public%% 
long%% 
Key%% 
{%% 
get%% 
;%% 
set%% "
;%%" #
}%%$ %
public&& 
string&& 
Title&& 
{&& 
get&& !
;&&! "
set&&# &
;&&& '
}&&( )
public'' 
string'' 
Author'' 
{'' 
get'' "
;''" #
set''$ '
;''' (
}'') *
public(( 
string(( 
CoverSrc(( 
{((  
get((! $
;(($ %
set((& )
;(() *
}((+ ,
public)) 
string)) 
Note)) 
{)) 
get))  
;))  !
set))" %
;))% &
}))' (
public** 
IList** 
<** 
BookType** 
>** 
Types** $
{**% &
get**' *
;*** +
set**, /
;**/ 0
}**1 2
public++ 

BookFormat++ 
Format++  
{++! "
get++# &
;++& '
set++( +
;+++ ,
}++- .
public,, 
bool,, 
IsRead,, 
{,, 
get,,  
;,,  !
set,," %
;,,& '
},,( )
public-- 
DateTime-- 
Date-- 
{-- 
get-- "
;--" #
set--$ '
;--' (
}--) *
public// 
Book// 
(// 
)// 
=>// 
IsRead// 
=//  !
false//" '
;//' (
}00 
}33 �
AC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Models\IMedia.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Models# )
{ 
public 

	interface 
IMedia 
{ 
long 
Key
{ 
get 
; 
set 
; 
} 
string 
Title 
{ 
get 
; 
set 
;  
}! "
string 
Author 
{ 
get 
; 
set  
;  !
}" #
System 
. 
DateTime 
Date 
{ 
get "
;" #
set$ '
;' (
}) *
}		 
}

 �	
;C:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Program.cs
	namespace 	$
BiblioWebApplicationCore
 "
{ 
public 

class 
Program 
{ 
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{		 	
var

 
host

 
=

 
new

 
WebHostBuilder

 )
(

) *
)

* +
. 

UseKestrel 
( 
) 
. 
UseContentRoot 
(  
	Directory  )
.) *
GetCurrentDirectory* =
(= >
)> ?
)? @
.
UseIISIntegration
(
)
. 

UseStartup 
< 
Startup #
># $
($ %
)% &
. 
UseUrls 
( 
$str 0
)0 1
. 
Build 
( 
) 
; 
host 
. 
Run 
( 
) 
; 
} 	
} 
} �"
;C:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Startup.cs
	namespace 	$
BiblioWebApplicationCore
 "
{ 
public		 

class		 
Startup		 
{

 
public 
Startup 
( 
IHostingEnvironment *
env+ .
). /
{ 	
var
builder
=
new
ConfigurationBuilder
(
)
. 
SetBasePath 
( 
env  
.  !
ContentRootPath! 0
)0 1
. 
AddJsonFile 
( 
$str /
,/ 0
optional1 9
:9 :
true; ?
,? @
reloadOnChangeA O
:O P
trueQ U
)U V
. 
AddJsonFile 
( 
$" 
appsettings. +
{+ ,
env, /
./ 0
EnvironmentName0 ?
}? @
.json@ E
"E F
,F G
optionalH P
:P Q
trueR V
)V W
. #
AddEnvironmentVariables (
(( )
)) *
;* +
if 
( 
env 
. 

(! "
)" #
)# $
builder 
. *
AddApplicationInsightsSettings 6
(6 7

:D E
trueF J
)J K
;K L

= 
builder #
.# $
Build$ )
() *
)* +
;+ ,
} 	
public 
IConfigurationRoot !

{0 1
get2 5
;5 6
}7 8
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. +
AddApplicationInsightsTelemetry 4
(4 5

)B C
;C D
services   
.   
AddMvc   
(   
)   
;   
services"" 
."" %
AddDistributedMemoryCache"" .
("". /
)""/ 0
;""0 1
services## 
.## 

AddSession## 
(##  
options##  '
=>##( *
{$$ 
options'' 
.'' 
CookieHttpOnly'' &
=''' (
true'') -
;''- .
}(( 
)((
;(( 
})) 	
public,, 
void,, 
	Configure,, 
(,, 
IApplicationBuilder,, 1
app,,2 5
,,,5 6
IHostingEnvironment,,7 J
env,,K N
,,,N O
ILoggerFactory,,P ^

),,l m
{-- 	
app.. 
... 

UseSession.. 
(.. 
).. 
;.. 

.// 

AddConsole// $
(//$ %

.//2 3

GetSection//3 =
(//= >
$str//> G
)//G H
)//H I
;//I J

.00 
AddDebug00 "
(00" #
)00# $
;00$ %
if44 
(44 
env44 
.44 

(44! "
)44" #
)44# $
{55 
app66 
.66 %
UseDeveloperExceptionPage66 -
(66- .
)66. /
;66/ 0
app77 
.77 
UseBrowserLink77 "
(77" #
)77# $
;77$ %
}88 
else99 
app:: 
.:: 
UseExceptionHandler:: '
(::' (
$str::( 5
)::5 6
;::6 7
app>> 
.>> 
UseStaticFiles>> 
(>> 
)>>  
;>>  !
app@@ 
.@@ 
UseMvc@@ 
(@@ 
routes@@ 
=>@@  
routes@@! '
.@@' (
MapRoute@@( 0
(@@0 1
nameAA 
:AA 
$strAA 
,AA  
templateBB 
:BB 
$strBB K
)BBK L
)BBL M
;BBM N
}CC 	
}DD 
}EE �
WC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeAddItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{		 
public

 

class

 


 
:

  


  -
{ 
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
)< =
{

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
)/ 0
;0 1
HttpResponseMessage 
response  (
= 
await 
client 
. 
GetAsync #
(# $
$str$ R
)R S
;S T
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
var 
obj 
= 
JsonConvert %
.% &
DeserializeObject& 7
<7 8
IEnumerable8 C
<C D
ModelsD J
.J K
TypeK O
>O P
>P Q
(Q R
resultR X
)X Y
;Y Z
return 
View 
( 
$str *
,* +
obj+ .
). /
;/ 0
} 
} 	
} 
} �
ZC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeDeleteItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{ 
public 

class 
InvokeDeleteItem !
:# $

{ 
public		 
async		 
Task		 
<		  
IViewComponentResult		 .
>		. /
InvokeAsync		0 ;
(		; <
int		< ?
[		? @
]		@ A
listitemskey		B N
)		N O
{

 	
string 
concat 
= 
$str 
; 
foreach 
( 
var 
item 
in  
listitemskey! -
)- .
{
concat 
= 
concat 
+  !
$str" %
+& '
item( ,
;, -
} 

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
)/ 0
;0 1
HttpResponseMessage 
response  (
= 
await 
client 
. 
DeleteAsync &
(& '
$str' I
+I J
concatJ P
)P Q
;Q R
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
return 
View 
( 
$str .
,. /
result0 6
)6 7
;7 8
} 
} 	
} 
} �0
ZC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeImportItem.cs
	namespace

 	$
BiblioWebApplicationCore


 "
.

" #
Views

# (
.

( )
Home

) -
.

- .

Components

. 8
{ 
public 

class 
InvokeImportItem !
:" #

{ 
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
string< B

nameofbookC M
)M N
{ 	
IList 
< 
string 
> 
imgInfo !
=" #
new$ '
List( ,
<, -
string- 3
>3 4
(4 5
)5 6
;6 7
Book 
book 
= 
new 
Book  
(  !
)! "
;" #

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
)/ 0
;0 1
HttpResponseMessage 
response  (
= 
await 
client 
. 
GetAsync #
(# $
$str	$ �
+
� �

nameofbook
� �
)
� �
;
� �
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
var 
htmlDoc 
= 
new !
HtmlDocument" .
(. /
)/ 0
;0 1
htmlDoc 
. 
LoadHtml  
(  !
result! '
)' (
;( )
var 
htmlBody 
= 
htmlDoc &
.& '
DocumentNode' 3
.3 4
SelectSingleNode4 D
(D E
$strE [
)[ \
;\ ]
foreach 
( 
var 
item !
in" $
htmlBody% -
.- .
Descendants. 9
(9 :
$str: ?
)? @
)@ A
{ 
if 
( 
item 
. 

Attributes '
[' (
$str( /
]/ 0
.0 1
Value1 6
.6 7
Contains7 ?
(? @
$str@ L
)L M
)M N
{   
var!! 
htmlImg!! #
=!!$ %
item!!& *
.!!* +
Descendants!!+ 6
(!!6 7
$str!!7 <
)!!< =
.!!= >
First!!> C
(!!C D
)!!D E
;!!E F
book"" 
."" 
CoverSrc"" %
=""& '
htmlImg""( /
.""/ 0

Attributes""0 :
["": ;
$str""; @
]""@ A
.""A B
Value""B G
;""G H
}## 
if$$ 
($$ 
item$$ 
.$$ 

Attributes$$ '
[$$' (
$str$$( /
]$$/ 0
.$$0 1
Value$$1 6
.$$6 7
Contains$$7 ?
($$? @
$str$$@ M
)$$M N
)$$N O
{%% 
var&& 
htmlFirstDiv&& (
=&&) *
item&&+ /
.&&/ 0
Descendants&&0 ;
(&&; <
$str&&< A
)&&A B
.&&B C
Where&&C H
(&&H I
p&&I J
=>&&K M
p&&N O
.&&O P

Attributes&&P Z
[&&Z [
$str&&[ b
]&&b c
.&&c d
Value&&d i
.&&i j
Contains&&j r
(&&r s
$str	&&s �
)
&&� �
)
&&� �
.
&&� �
First
&&� �
(
&&� �
)
&&� �
;
&&� �
var'' 
	htmlTitle'' %
=''& '
htmlFirstDiv''( 4
.''4 5
Descendants''5 @
(''@ A
$str''A E
)''E F
.''F G
First''G L
(''L M
)''M N
;''N O
book(( 
.(( 
Title(( "
=((# $
	htmlTitle((% .
.((. /
	InnerText((/ 8
;((8 9
var)) 

htmlAuthor)) &
=))' (
htmlFirstDiv))) 5
.))5 6
Descendants))6 A
())A B
$str))B H
)))H I
.))I J
Where))J O
())O P
p))P Q
=>))R T
p))U V
.))V W
	InnerText))W `
!=))a c
$str))d f
)))f g
;))g h
foreach** 
(**  !
var**! $
spany**% *
in**+ -

htmlAuthor**. 8
)**8 9
{++ 
imgInfo,, #
.,,# $
Add,,$ '
(,,' (
spany,,( -
.,,- .
	InnerText,,. 7
),,7 8
;,,8 9
}-- 
}.. 
}// 
for00 
(00 
int00 
i00 
=00 
$num00 
;00 
i00  !
<00" #
imgInfo00$ +
.00+ ,
Count00, 1
;001 2
i003 4
++004 6
)006 7
book11 
.11 
Author11 
=11  
book11! %
.11% &
Author11& ,
+11- .
imgInfo11/ 6
[116 7
i117 8
]118 9
;119 :
book22 
.22 
Date22 
=22 
DateTime22 $
.22$ %
Parse22% *
(22* +
imgInfo22+ 2
[222 3
$num223 4
]224 5
)225 6
.226 7
ToUniversalTime227 F
(22F G
)22G H
;22H I
return33 
View33 
(33 
$str33 .
,33. /
book33/ 3
)333 4
;334 5
}44 
}55 	
}66 
}77 �
ZC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeIsReadItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{ 
public 

class 
InvokeIsReadItem !
:" #

{		 
public

 
async

 
Task

 
<

  
IViewComponentResult

 .
>

. /
InvokeAsync

0 ;
(

; <
int

< ?
key

@ C
,

C D
string

E K
isRead

L R
)

R S
{ 	
var 

putContent 
= 
new 

(- .
$str. :
+: ;
isRead< B
+C D
$strD G
,G H
EncodingI Q
.Q R
UTF8R V
,V W
$strX j
)j k
;k l

HttpClient
client
=
new

HttpClient
(
)
;
HttpResponseMessage 
response  (
= 
await 
client 
. 
PutAsync #
(# $
$str$ F
+G H
keyI L
,L M

putContentN X
)X Y
;Y Z
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
return 
View 
( 
$str .
,. /
result0 6
)6 7
;7 8
} 
} 	
} 
} �
XC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeListItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{		 
public

 

class

 
InvokeListItem

 
:

  !


" /
{ 
public
IViewComponentResult
InvokeNormal
(
)
{ 	
return 
View 
( 
) 
; 
} 	
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
)< =
{ 	
using 
( 

HttpClient 
client $
=% &
new' *

HttpClient+ 5
(5 6
)6 7
)7 8
using 
( 
HttpResponseMessage &
response' /
=0 1
await2 7
client8 >
.> ?
GetAsync? G
(G H
$strH i
)i j
)j k
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
var 
obj 
= 
JsonConvert %
.% &
DeserializeObject& 7
<7 8
IEnumerable8 C
<C D
BookD H
>H I
>I J
(J K
resultK Q
)Q R
;R S
return 
View 
( 
$str +
,+ ,
obj- 0
)0 1
;1 2
} 
} 	
} 
} �
XC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeNoteItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{ 
public		 

class		 
InvokeNoteItem		 
:		  !

{

 
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
int< ?
key@ C
,C D
stringE K
noteL P
)P Q
{ 	
var
noteJson
=
JsonConvert
.
SerializeObject
(
new
{
key
=
key
,
note
=
note
}
)
;
var 
postContent 
= 
new !

(/ 0
noteJson0 8
,8 9
Encoding: B
.B C
UTF8C G
,G H
$strI [
)[ \
;\ ]

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
)/ 0
;0 1
HttpResponseMessage 
response  (
= 
await 
client 
. 
	PostAsync $
($ %
$str% K
,K L
postContentM X
)X Y
;Y Z
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
return 
View 
( 
$str ,
,, -
result. 4
)4 5
;5 6
} 
} 	
} 
} �
XC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeSaveItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{		 
public

 

class

 
InvokeSaveItem

 
:

  !


" /
{ 
public 
async 
Task 
<  
IViewComponentResult .
>. /
InvokeAsync0 ;
(; <
string< B
bookC G
)G H
{

HttpClient 
client 
= 
new  #

HttpClient$ .
(. /
)/ 0
;0 1
var 
postContent 
= 
new !

(/ 0
book0 4
,4 5
Encoding5 =
.= >
UTF8> B
,B C
$strD V
)V W
;W X
HttpResponseMessage 
response  (
= 
await 
client 
. 
	PostAsync $
($ %
$str% F
,F G
postContentH S
)S T
;T U
using 
( 
HttpContent 
content &
=' (
response) 1
.1 2
Content2 9
)9 :
{ 
string 
result 
= 
await  %
content& -
.- .
ReadAsStringAsync. ?
(? @
)@ A
;A B
var 
obj 
= 
JsonConvert %
.% &
DeserializeObject& 7
<7 8
Book8 <
>< =
(= >
result> D
)D E
;E F
return 
View 
( 
$str .
,. /
obj0 3
)3 4
;4 5
} 
} 	
} 
} �
ZC:\webapp\BiblioWeb\src\BiblioWebApplicationCore\Views\Home\Components\InvokeSearchItem.cs
	namespace 	$
BiblioWebApplicationCore
 "
." #
Views# (
.( )
Home) -
.- .

Components. 8
{ 
public 

class 
InvokeSearchItem !
:" #

{ 
public  
IViewComponentResult #
Invoke$ *
(* +
)+ ,
{		 	
return

 
View

 
(

 
$str

 -
)

- .
;

. /
} 	
} 
}