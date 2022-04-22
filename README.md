Tugas Besar 2 PBD - Unity
<h1> Survival Shooter </h1>
<h2> Deskripsi Aplikasi </h2>
<p>
    Aplikasi ini berjudul Survival Shooter dan merupakan permainan/game yang dibuat untuk memenuhi tugas besar Platform Based Development.
    Aplikasi ini dibuat dengan menggunakan Unity.
</p>
<h2> Cara Kerja </h2>
<p> Aplikasi ini memanfaatkan unity dalam implementasi. Aplikasi ini merupakan permainan survival shooter, yaitu sebuah permainan/game shooter third person. Ada 2 mode yang diintegrasikan dalam permainan ini, yaitu survival, di mana pemain harus bertahan hidup selama mungkin, dan wave mode, di mana pemain harus bertahan hidup dan menyelesaikan wave-wave yang ada. </p>
<p> Game ini dibuat dengan memanfaatkan hirarki-hirarki dari game object yang disusun sedemikian rupa sehingga permainan dapat dijalankan. Adapun game objects yang ada pada game ini adalah sebagai berikut : </br>

- Event System &rarr; Game object untuk mengontrol event-event yang terjadi pada game 
- Canvas &rarr; Sebagai UI untuk membuka weapon upgrade
- Main Camera &rarr; Sebagai kamera utama pada permainan 
- Environment &rarr; Sebagai latar permainan 
- Lights &rarr; Sebagai penerangan pada permainan 
- Floor &rarr; Sebagai lantai dari permainan 
- Player &rarr; Sebagai pemain yang akan bertahan hidup selama mungkin 
- EnemyManagerWave &rarr; Sebagai pengatur enemy dalam wave mode 
- SkeletonSpawnPoint &rarr; Sebagai titik spawn dari skeleton 
- ZombunnySpawnPoint &rarr; Sebagai titik spawn dari zombunny 
- ZombearSpawnPoint &rarr; Sebagai titik spawn dari zombear 
- HellephantSpawnPoint &rarr; Sebagai titik spawn dari hellephant 
- PowerUpManager &rarr; Sebagai pengatur power up yang ada pada permainan 
- PowerSpawnPoint &rarr; Sebagai titik spawn dari orb power up 
- SpeedSpawnPoint &rarr; Sebagai titik spawn dari orb speed up 
- HealthSpawnPoint &rarr; Sebagai titik spawn dari orb health 
- PowerUpFactory &rarr; Sebagai pengatur spawner untuk powerups 
- MouseySpawnPoint &rarr; Sebagai titik spawn dari mousey 
- EnemyFactoryWave &rarr; Sebagai pengatur spawner untuk enemy dalam wave mode 

<h2> Screenshot </h3>
<p> Main Menu </p>
![Main Menu](/Screenshots/mainmenu.jpg)
<p> Settings </p>
![Settings](/Screenshots/settings.jpg)
<p> Change Name </p>
![Change Name](/Screenshots/changename.jpg)
<p> Game Mode </p>
![Game Mode](/Screenshots/gamemode.jpg)
<p> Weapon Upgrade </p>
![Weapon Upgrade](/Screenshots/weaponupgrade.jpg)
<p> Game Over </p>
![Game Over](/Screenshots/gameover.jpg)
<p> Wave Mode </p>
![Wave Mode](/Screenshots/wavemode.jpg)
<p> Zen Mode </p>
![Zen Mode](/Screenshots/zenmode.jpg)
<p> Map Zen </p>
![Map Zen](/Screenshots/mapzen.jpg)
<p> Map Wave </p>
![Map Wave](/Screenshots/mapwave.jpg)
<p> Construction Wave</p>
![Construction](/Screenshots/construction.jpg)
<p> Construction Zen </p>
![Construction Zen](/Screenshots/constructionzen.jpg)

</p>

<h2> Library yang digunakan </h2>
- LinQ -> digunakan untuk menggunakan linked queue, yaitu queue yang menggunakan linked list untuk mengurutkan skor-skor pada scoreboard. <br/>
- List -> digunakan untuk menyimpan LineRenderer guna untuk melakukan rendering terhadap upgrade weapon yang menambah arah tembak.
<h2> Pembagian Kerja </h2>

| NIM      | Nama            | Pembagian Kerja                                                      |
|----------|-----------------|----------------------------------------------------------------------|
| 13519163 | Alvin Wilta     | Boss mob, Wave mode, Main Menu, Game Over, Map                       |
| 13519191 | Kevin Ryan      | Bomber mob, Weapon upgrade + bonus                                   |
| 13519215 | Leonard Matheus | Attribute, Orbs, Skeleton mob, Zen mode, Scoreboard, Menu, Game Over |
