extends Node2D

var player := Vector2(270,650)
var money := 0
var item := "VAZIO"
var count := 0
var joy := Vector2.ZERO
var touch_origin := Vector2.ZERO
var touch_id := -1
var zones = [
 {"name":"TRIGO","r":Rect2(25,90,150,170),"c":Color("#8fbd4a")},
 {"name":"MOINHO","r":Rect2(200,120,130,110),"c":Color("#d5b06d")},
 {"name":"BANCADA","r":Rect2(365,120,145,110),"c":Color("#f2d2a2")},
 {"name":"FORNO","r":Rect2(365,300,145,110),"c":Color("#c96545")},
 {"name":"BALCAO","r":Rect2(365,490,145,100),"c":Color("#e8a95e")}
]
var cooldown := 0.0

func _ready():
 money = int(load_money())
 queue_redraw()

func _process(delta):
 cooldown=maxf(0,cooldown-delta)
 player += joy*240.0*delta
 player.x=clampf(player.x,25,515); player.y=clampf(player.y,70,875)
 interact()
 queue_redraw()

func interact():
 if cooldown>0:return
 for z in zones:
  if z.r.grow(20).has_point(player):
   match z.name:
    "TRIGO":
     if (item=="VAZIO" or item=="TRIGO") and count<5:item="TRIGO";count+=1;cooldown=.45
    "MOINHO":
     if item=="TRIGO" and count>=3:item="MASSA";count=1;cooldown=1
    "BANCADA":
     if item=="MASSA":item="PIZZA CRUA";count=1;cooldown=1
    "FORNO":
     if item=="PIZZA CRUA":item="PIZZA ASSADA";count=1;cooldown=1.5
    "BALCAO":
     if item=="PIZZA ASSADA":item="VAZIO";count=0;money+=12;save_money();cooldown=.5

func _input(e):
 if e is InputEventScreenTouch:
  if e.pressed and e.position.x<270 and e.position.y>650:
   touch_id=e.index;touch_origin=e.position
  elif not e.pressed and e.index==touch_id:
   touch_id=-1;joy=Vector2.ZERO
 if e is InputEventScreenDrag and e.index==touch_id:
  joy=(e.position-touch_origin).limit_length(70)/70.0
 if e is InputEventMouseButton:
  if e.pressed:touch_origin=e.position
  else:joy=Vector2.ZERO
 if e is InputEventMouseMotion and Input.is_mouse_button_pressed(MOUSE_BUTTON_LEFT):
  joy=(e.position-touch_origin).limit_length(70)/70.0

func _draw():
 draw_rect(Rect2(0,0,540,960),Color("#8bcf78"))
 draw_rect(Rect2(15,55,510,835),Color("#efd6a1"))
 for z in zones:
  draw_rect(z.r,z.c,true);draw_rect(z.r,Color("#5a4535"),false,4)
  draw_string(ThemeDB.fallback_font,z.r.position+Vector2(12,28),z.name,HORIZONTAL_ALIGNMENT_LEFT,-1,18,Color("#33281f"))
 draw_circle(player,24,Color("#3d72d9"));draw_circle(player-Vector2(0,13),12,Color("#f1c29b"))
 for i in range(count):
  draw_rect(Rect2(player.x-15,player.y-45-i*9,30,7),Color("#f3c65a"))
 draw_rect(Rect2(15,10,510,38),Color("#ffffffcc"))
 draw_string(ThemeDB.fallback_font,Vector2(30,36),"PIZZA EMPIRE   $%d   %s %d/5"%[money,item,count],HORIZONTAL_ALIGNMENT_LEFT,-1,19,Color("#2b2b2b"))
 draw_circle(Vector2(100,820),72,Color("#ffffff55"));draw_circle(Vector2(100,820)+joy*55,30,Color("#ffffffaa"))
 draw_string(ThemeDB.fallback_font,Vector2(28,925),"Aproxime-se das estacoes: trigo > moinho > bancada > forno > balcao",HORIZONTAL_ALIGNMENT_LEFT,-1,13,Color("#3b3028"))

func save_money():
 var f=FileAccess.open("user://save.txt",FileAccess.WRITE);f.store_string(str(money))
func load_money():
 if FileAccess.file_exists("user://save.txt"):return FileAccess.get_file_as_string("user://save.txt")
 return "0"
