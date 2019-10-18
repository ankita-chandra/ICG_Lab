import pygame
pygame.init()

def start():
    screenHeight=600
    screenWidth=400

    canvas=pygame.display.set_mode((screenWidth,screenHeight))
    pygame.display.set_caption("Color Hit")

    run = True
    playerPosX=180
    playerPosY=500
    playerWidth=40
    playerHeight=40
    playerVel=0.25
    boundary=(playerWidth/2)+5
    surf=pygame.Surface((100,100))

    RED = (255,0,0)
    GREEN = (0, 255, 0)
    BLUE = (0, 0, 255)
    BLACK = (0,0,0)
    WHITE = (255,255,255)

    # def SpawnBars():
    #     # dkn

    # def SpawnPlayer(color):
    # player=pygame.Rect(playerPosX,playerPosY,playerWidth,playerHeight)
    # surf=pygame.Surface((100,100))
    # pygame.transform.rotate(surf,45)
    # player.image=pygame.transform.rotate(surf,45)
    # player.rect=player.image.get_rect()
    def SpawnPlayer(color):
        pygame.draw.rect(canvas,color,(playerPosX,playerPosY,playerWidth,playerHeight))
        pygame.display.update()

    while run:
        for event in pygame.event.get():
            if event.type==pygame.QUIT :
                run = False
            # if event.type==pygame.MOUSEBUTTONUP:
            #     pygame.draw.rect(canvas,RED,(100,100,100,100))
            #     pygame.display.update()

        # Spawn Player
        SpawnPlayer(RED)
        # --------------

        # Take input and Move
        input=pygame.key.get_pressed()
        if input[pygame.K_LEFT] and playerPosX > boundary:
            playerPosX-=playerVel

        if input[pygame.K_RIGHT] and playerPosX < screenWidth-playerWidth-boundary:
            playerPosX+=playerVel

        canvas.fill(BLACK)
        # --------------
        # SpawnBars()


start()
pygame.quit()
