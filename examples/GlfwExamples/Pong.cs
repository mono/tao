#region License
/*
 MIT License
 Copyright ©2003-2006 The Tao Framework Team
 http://www.taoframework.com
 All rights reserved.
 
 Permission is hereby granted, free of charge, to any person obtaining a copy
 of this software and associated documentation files (the "Software"), to deal
 in the Software without restriction, including without limitation the rights
 to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 copies of the Software, and to permit persons to whom the Software is
 furnished to do so, subject to the following conditions:
 
 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.
 
 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 SOFTWARE.
 */
#endregion License

#region Tao Port Credits
/* Original Tao port by Simon <the-real-sim@gmx.de> */
#endregion Tao Port Credits

#region Original Credits/License
/*
 Copyright (c) 2002-2004 Marcus Geelnard
 
 This software is provided 'as-is', without any express or implied
 warranty. In no event will the authors be held liable for any damages
 arising from the use of this software.
 
 Permission is granted to anyone to use this software for any purpose,
 including commercial applications, and to alter it and redistribute it
 freely, subject to the following restrictions:
 
 1. The origin of this software must not be misrepresented; you must not
 claim that you wrote the original software. If you use this software
 in a product, an acknowledgment in the product documentation would
 be appreciated but is not required.
 
 2. Altered source versions must be plainly marked as such, and must not
 be misrepresented as being the original software.
 
 3. This notice may not be removed or altered from any source
 distribution.
 
 Marcus Geelnard
 marcus.geelnard at home.se
 */

//========================================================================
// This is a small test application for GLFW.
// This is an OpenGL port of the famous "PONG" game (the first computer
// game ever?). It is very simple, and could be improved alot. It was
// created in order to show off the gaming capabilities of GLFW.
//========================================================================
#endregion Original Credits/License

using System;
using Tao.Glfw;
using Tao.OpenGl;

namespace GlfwExamples {
	#region Class Documentation
	/// <summary>
	/// This is a small test application for GLFW
	/// </summary>
	/// <remarks>
	/// This is an OpenGL port of the famous "PONG" game (the first computer
  /// game ever?). It is very simple, and could be improved alot. It was
  /// created in order to show off the gaming capabilities of GLFW.
	/// </remarks>
	#endregion Class Documentation
	public sealed class Pong {
		
		#region fields
		
		/// <summary> Screen resolution: width </summary>
		public static int width = 640;

		/// <summary> Screen resolution: height </summary>
		public static int height = 480;
		
		/// <summary> Player size (units): X dimension </summary>
		public static float playerSizeX = 0.05f;

		/// <summary> Player size (units): Y dimension </summary>
		public static float playerSizeY = 0.15f;
		
		/// <summary> Ball size (units) </summary>
		public static float ballSize = 0.02f;
		
		/// <summary> Maximum player movement speed (units / second) </summary>
		public static float maxSpeed = 1.5f;
		
		/// <summary> Player movement acceleration (units / seconds^2) </summary>
		public static float acceleration = 4.0f;
		
		/// <summary> Player movement deceleration (units / seconds^2) </summary>
		public static float deceleration = 2.0f;
		
		/// <summary> Ball movement speed (units / second) </summary>
		public static float ballSpeed = 0.4f;
		
		/// <summary>
		///  Menu options
		/// </summary>
		public enum MenuOption {
			None,Play,Quit
		}
		/// <summary>
		/// Game events
		/// </summary>
		public enum GameEvent {
			NobodyWins,
			Player1Wins,
			Player2Wins
		}
		
		/// <summary>
		/// Game winners
		/// </summary>
		public enum Winner {
			Nobody,
			Player1,
			Player2
		}
		
		/// <summary> The winning player </summary>
		public static int winningPlayer;
		
		/// <summary>
		///  Camera positions
		/// </summary>
		public enum CameraPosition {
			Classic,
			Above,
			Spectator
		}
		
		/// <summary> Default camera position </summary>
		public static CameraPosition cameraDefault = CameraPosition.Classic;
		
		
		/// <summary>
		/// Textures
		/// </summary>
		public enum Textures {
			Title,
			Menu,
			Instr,
			Winner1,
			Winner2,
			Field,
			Num_textures
		}

		/// <summary>
		/// Texture file names
		/// </summary>
		public static String[] TexName = {"Data/pong3d_title.tga",
			"Data/pong3d_menu.tga",
			"Data/pong3d_instr.tga",
			"Data/pong3d_winner1.tga",
			"Data/pong3d_winner2.tga",
			"Data/pong3d_field.tga"};
		
		/// <summary> Frame information </summary>
		public static double thisTime, oldTime, dt, startTime;
		
		/// <summary> Camera position information </summary>
		public static CameraPosition cameraPos;
		
		/// <summary>
		///  Player information
		/// </summary>
		public struct Player {
			/// <summary> Player Id: Player 1 or Player 2 </summary>
			public int id;
			/// <summary> Y-position of player paddle: -1.0 to +1.0 </summary>
			public double posY;
			/// <summary> Maximum speed of player paddle: -MAX_SPEED to +MAX_SPEED </summary>
			public double speedY;   
		}
		
		/// <summary>Players</summary>
		public static Player Player1,Player2;
		
		/// <summary> Ball information </summary>
		public struct Ball {
			public double posX, posY;
			public double speedX, speedY;
		}
		
		/// <summary> The game ball </summary>
		public static Ball gameBall;
		
		#region Lighting configuration
		public static float[] envAmbient;
		public static float[] light1Position;
		public static float[] light1Diffuse;
		public static float[] light1Ambient;
		#endregion Lighting configuration
		
		#region Object material properties
		public static float[] Player1Diffuse;
		public static float[] Player1Ambient;
		public static float[] Player2Diffuse;
		public static float[] Player2Ambient;
		public static float[] ballDiffuse;
		public static float[] ballAmbient;
		public static float[] borderDiffuse;
		public static float[] borderAmbient;
		public static float[] floorDiffuse;
		public static float[] floorAmbient;
		#endregion Object material properties
		
		/// <summary> OpenGL texture object IDs </summary>
		public static int[] TexId = new int[(int)Textures.Num_textures];
		
		#endregion fields
		
		/// <summary>
		/// LoadTextures
		/// 
		/// Load textures from disk and upload to OpenGL card
		/// </summary>
		public static void LoadTextures() {
			int  i;
			
			// Generate texture objects
			Gl.glGenTextures((int)Textures.Num_textures, TexId);
			
			// Load textures 
			for(i = 0; i < (int)Textures.Num_textures; i++) {
				
				// Select texture object
				Gl.glBindTexture(Gl.GL_TEXTURE_2D, TexId[i]);
				
				// Set texture parameters
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_S, Gl.GL_REPEAT);
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_WRAP_T, Gl.GL_REPEAT);
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MAG_FILTER, Gl.GL_LINEAR);
				Gl.glTexParameteri(Gl.GL_TEXTURE_2D, Gl.GL_TEXTURE_MIN_FILTER, Gl.GL_LINEAR);
				
				// Upload texture from file to texture memory
				Glfw.glfwLoadTexture2D(TexName[i], 0);
			}
		}
		
		/// <summary>
		/// DrawImage
		/// 
		/// Draw a 2d image as a texture
		/// </summary>
		/// <param name="texnum">An int</param>
		/// <param name="x1">A  float</param>
		/// <param name="x2">A  float</param>
		/// <param name="y1">A  float</param>
		/// <param name="y2">A  float</param>
		public static void DrawImage(int texnum, float x1, float x2, float y1, float y2) {
			Gl.glEnable(Gl.GL_TEXTURE_2D);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, TexId[texnum]);
			Gl.glBegin(Gl.GL_QUADS);
			Gl.glTexCoord2f(0.0f, 1.0f);
			Gl.glVertex2f(x1, y1);
			Gl.glTexCoord2f(1.0f, 1.0f);
			Gl.glVertex2f(x2, y1);
			Gl.glTexCoord2f(1.0f, 0.0f);
			Gl.glVertex2f(x2, y2);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex2f(x1, y2);
			Gl.glEnd();
			Gl.glDisable(Gl.GL_TEXTURE_2D);
		}
		
		/// <summary>
		/// GameMenu
		/// 
		/// Returns menu option
		/// </summary>
		/// <returns>A MenuOption</returns>
		public static MenuOption GameMenu() {
			MenuOption option;
			
			// Enable sticky keys
			Glfw.glfwEnable(Glfw.GLFW_STICKY_KEYS);
			
			// Wait for a game menu key to be pressed
			do
			{
				// Get window size
				Glfw.glfwGetWindowSize(out width, out height);
				
				// Set viewport
				Gl.glViewport(0, 0, width, height);
				
				// Clear display
				Gl.glClearColor(0.0f, 0.0f, 0.0f, 0.0f);
				Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
				
				// Setup projection matrix
				Gl.glMatrixMode(Gl.GL_PROJECTION);
				Gl.glLoadIdentity();
				Gl.glOrtho(0.0f, 1.0f, 1.0f, 0.0f, -1.0f, 1.0f);
				
				// Setup modelview matrix
				Gl.glMatrixMode(Gl.GL_MODELVIEW);
				Gl.glLoadIdentity();
				
				// Display title
				Gl.glColor3f(1.0f, 1.0f, 1.0f);
				DrawImage((int)Textures.Title, 0.1f, 0.9f, 0.0f, 0.3f);
				
				// Display menu
				Gl.glColor3f(1.0f, 1.0f, 0.0f);
				DrawImage((int)Textures.Menu, 0.38f, 0.62f, 0.35f, 0.5f);
				
				// Display instructions
				Gl.glColor3f(0.0f, 1.0f, 1.0f);
				DrawImage((int)Textures.Instr, 0.32f, 0.68f, 0.65f, 0.85f);
				
				// Swap buffers
				Glfw.glfwSwapBuffers();
				
				// Check for keys
				if(Glfw.glfwGetKey('Q') == Gl.GL_TRUE || Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_FALSE) {
					option = MenuOption.Quit;
				}
				else if(Glfw.glfwGetKey(Glfw.GLFW_KEY_F1) == Gl.GL_TRUE) {
					option = MenuOption.Play;
				}
				else {
					option = MenuOption.None;
				}
				
				// To avoid horrible busy waiting, sleep for at least 20 ms
				Glfw.glfwSleep(0.02);
			}
			while( option == MenuOption.None );
			
			// Disable sticky keys
			Glfw.glfwDisable(Glfw.GLFW_STICKY_KEYS);
			
			return option;
		}
		
		/// <summary>
		/// NewGame
		/// 
		/// Initialize a new game
		/// </summary>
		public static void NewGame() {
			// Frame information
			startTime = thisTime = Glfw.glfwGetTime();
			
			// Camera information
			cameraPos = cameraDefault;
			
			// Player 1 information
			Player1.posY   = 0.0;
			Player1.speedY = 0.0;
			
			// Player 2 information
			Player2.posY   = 0.0;
			Player2.speedY = 0.0;
			
			// Ball information
			gameBall.posX = -1.0 + playerSizeX;
			gameBall.posY = Player1.posY;
			gameBall.speedX = 1.0;
			gameBall.speedY = 1.0;
		}
		
		/// <summary>
		/// PlayerControl
		/// </summary>
		public static void PlayerControl() {
			float[] joy1pos = new float[2];
			float[] joy2pos = new float[2];
			
			// Get joystick X & Y axis positions
			Glfw.glfwGetJoystickPos(Glfw.GLFW_JOYSTICK_1, joy1pos, 2);
			Glfw.glfwGetJoystickPos(Glfw.GLFW_JOYSTICK_2, joy2pos, 2);
			
			// Player 1 control
			if(Glfw.glfwGetKey('A') == Gl.GL_TRUE || joy1pos[1] > 0.2f) {
				Player1.speedY += dt * acceleration;
				if(Player1.speedY > maxSpeed) {
					Player1.speedY = maxSpeed;
				}
			}
			else if(Glfw.glfwGetKey('Z') == Gl.GL_TRUE || joy1pos[1] < -0.2f) {
				Player1.speedY -= dt * acceleration;
				if(Player1.speedY < -maxSpeed) {
					Player1.speedY = -maxSpeed;
				}
			}
			else {
				Player1.speedY /= System.Math.Exp(deceleration * dt);
			}
			
			// Player 2 control
			if(Glfw.glfwGetKey('K') == Gl.GL_TRUE || joy2pos[1] > 0.2f) {
				Player2.speedY += dt * acceleration;
				if(Player2.speedY > maxSpeed) {
					Player2.speedY = maxSpeed;
				}
			}
			else if(Glfw.glfwGetKey('M') == Gl.GL_TRUE || joy2pos[1] < -0.2f) {
				Player2.speedY -= dt * acceleration;
				if(Player2.speedY < -maxSpeed) {
					Player2.speedY = -maxSpeed;
				}
			}
			else {
				Player2.speedY /= System.Math.Exp(deceleration * dt);
			}
			
			// Update player 1 position
			Player1.posY += dt * Player1.speedY;
			if(Player1.posY > 1.0 - playerSizeY) {
				Player1.posY = 1.0 - playerSizeY;
				Player1.speedY = 0.0;
			}
			else if(Player1.posY < -1.0 + playerSizeY) {
				Player1.posY = -1.0 + playerSizeY;
				Player1.speedY = 0.0;
			}
			
			// Update player 2 position
			Player2.posY += dt * Player2.speedY;
			if(Player2.posY > 1.0 - playerSizeY) {
				Player2.posY = 1.0 - playerSizeY;
				Player2.speedY = 0.0;
			}
			else if(Player2.posY < -1.0 + playerSizeY) {
				Player2.posY = -1.0 + playerSizeY;
				Player2.speedY = 0.0;
			}
		}
		
		/// <summary>
		/// UpdateDisplay
		/// 
		/// Draw graphics (all game related OpenGL stuff goes here)
		/// </summary>
		public static void UpdateDisplay() {
			// Get window size
			Glfw.glfwGetWindowSize(out width, out height);
			
			// Set viewport
			Gl.glViewport(0, 0, width, height);
			
			// Clear display
			Gl.glClearColor(0.02f, 0.02f, 0.02f, 0.0f);
			Gl.glClearDepth(1.0f);
			Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
			
			// Setup projection matrix
			Gl.glMatrixMode(Gl.GL_PROJECTION);
			Gl.glLoadIdentity();
			Glu.gluPerspective(
				55.0f,							// Angle of view
				(float)width / (float)height,		// Aspect
				1.0f,							// Near Z
				100.0f							// Far Z
			);
			
			// Setup modelview matrix
			Gl.glMatrixMode(Gl.GL_MODELVIEW);
			Gl.glLoadIdentity();
			
			switch(cameraPos) {
				default:
				case CameraPosition.Classic:
					Glu.gluLookAt(
						0.0f, 0.0f, 2.5f,
						0.0f, 0.0f, 0.0f,
						0.0f, 1.0f, 0.0f
					);
					break;
					
				case CameraPosition.Above:
					Glu.gluLookAt(
						0.0f, 0.0f, 2.5f,
						(float)gameBall.posX, (float)gameBall.posY, 0.0f,
						0.0f, 1.0f, 0.0f
					);
					break;
					
				case CameraPosition.Spectator:
					Glu.gluLookAt(
						0.0f, -2.0, 1.2f,
						(float)gameBall.posX, (float)gameBall.posY, 0.0f,
						0.0f, 0.0f, 1.0f
					);
					break;
			}
			
			// Enable depth testing
			Gl.glEnable(Gl.GL_DEPTH_TEST);
			Gl.glDepthFunc(Gl.GL_LEQUAL);
			
			// Enable lighting
			Gl.glEnable(Gl.GL_LIGHTING);
			Gl.glLightModelfv(Gl.GL_LIGHT_MODEL_AMBIENT, envAmbient);
			Gl.glLightModeli(Gl.GL_LIGHT_MODEL_LOCAL_VIEWER, Gl.GL_TRUE);
			Gl.glLightModeli(Gl.GL_LIGHT_MODEL_TWO_SIDE, Gl.GL_FALSE);
			Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light1Position);
			Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE,  light1Diffuse);
			Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT,  light1Ambient);
			Gl.glEnable(Gl.GL_LIGHT1);
			
			// Front face is counter-clock-wise
			Gl.glFrontFace(Gl.GL_CCW);
			
			// Enable face culling (not necessary, but speeds up rendering)
			Gl.glCullFace(Gl.GL_BACK);
			Gl.glEnable(Gl.GL_CULL_FACE);
			
			// Draw Player 1
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Player1Diffuse);
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Player1Ambient);
			DrawBox(-1.0f,              (float)Player1.posY - playerSizeY, 0.0f,
							-1.0f + playerSizeX, (float)Player1.posY + playerSizeY, 0.1f);
			
			// Draw Player 2
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, Player2Diffuse);
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, Player2Ambient);
			DrawBox(1.0f - playerSizeX, (float)Player2.posY - playerSizeY, 0.0f,
							1.0f,              (float)Player2.posY + playerSizeY, 0.1f);
			
			// Draw Ball
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, ballDiffuse);
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, ballAmbient);
			DrawBox((float)gameBall.posX - ballSize, (float)gameBall.posY - ballSize, 0.0f,
							(float)gameBall.posX + ballSize, (float)gameBall.posY + ballSize, ballSize * 2);
			
			// Top game field border
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, borderDiffuse);
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, borderAmbient);
			DrawBox(-1.1f, 1.0f, 0.0f,  1.1f, 1.1f, 0.1f);
			// Bottom game field border
			Gl.glColor3f(0.0f, 0.0f, 0.7f);
			DrawBox(-1.1f, -1.1f, 0.0f,  1.1f, -1.0f, 0.1f);
			// Left game field border
			DrawBox(-1.1f, -1.0f, 0.0f,  -1.0f, 1.0f, 0.1f);
			// Left game field border
			DrawBox(1.0f, -1.0f, 0.0f,  1.1f, 1.0f, 0.1f);
			
			// Enable texturing
			Gl.glEnable(Gl.GL_TEXTURE_2D);
			Gl.glBindTexture(Gl.GL_TEXTURE_2D, TexId[(int)Textures.Field]);
			
			// Game field floor
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_DIFFUSE, floorDiffuse);
			Gl.glMaterialfv(Gl.GL_FRONT, Gl.GL_AMBIENT, floorAmbient);
			DrawBox(-1.01f, -1.01f, -0.01f,  1.01f, 1.01f, 0.0f);
			
			// Disable texturing
			Gl.glDisable(Gl.GL_TEXTURE_2D);
			
			// Disable face culling
			Gl.glDisable(Gl.GL_CULL_FACE);
			
			// Disable lighting
			Gl.glDisable(Gl.GL_LIGHTING);
			
			// Disable depth testing
			Gl.glDisable(Gl.GL_DEPTH_TEST);
		}
		
		/// <summary>
		/// GameOver
		/// </summary>
		public static void GameOver() {
			// Enable sticky keys
			Glfw.glfwEnable(Glfw.GLFW_STICKY_KEYS);
			
			// Until the user presses ESC or SPACE
			while(Glfw.glfwGetKey(Glfw.GLFW_KEY_ESC) == Gl.GL_FALSE && Glfw.glfwGetKey(' ') == Gl.GL_FALSE &&
						Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_TRUE) {
				// Draw display
				UpdateDisplay();
				
				// Setup projection matrix
				Gl.glMatrixMode(Gl.GL_PROJECTION);
				Gl.glLoadIdentity();
				Gl.glOrtho(0.0f, 1.0f, 1.0f, 0.0f, -1.0f, 1.0f);
				
				// Setup modelview matrix
				Gl.glMatrixMode(Gl.GL_MODELVIEW);
				Gl.glLoadIdentity();
				
				// Enable blending
				Gl.glEnable(Gl.GL_BLEND);
				
				// Dim background
				Gl.glBlendFunc(Gl.GL_ONE_MINUS_SRC_ALPHA, Gl.GL_SRC_ALPHA);
				Gl.glColor4f(0.3f, 0.3f, 0.3f, 0.3f);
				Gl.glBegin(Gl.GL_QUADS);
				Gl.glVertex2f(0.0f, 0.0f);
				Gl.glVertex2f(1.0f, 0.0f);
				Gl.glVertex2f(1.0f, 1.0f);
				Gl.glVertex2f(0.0f, 1.0f);
				Gl.glEnd();
				
				// Display winner text
				Gl.glBlendFunc(Gl.GL_ONE, Gl.GL_ONE_MINUS_SRC_COLOR);
				if(winningPlayer == (int)Winner.Player1) {
					Gl.glColor4f(1.0f, 0.5f, 0.5f, 1.0f);
					DrawImage((int)Textures.Winner1, 0.35f, 0.65f, 0.46f, 0.54f);
				}
				else if(winningPlayer == (int)Winner.Player2) {
					Gl.glColor4f(0.5f, 1.0f, 0.5f, 1.0f);
					DrawImage((int)Textures.Winner2, 0.35f, 0.65f, 0.46f, 0.54f);
				}
				
				// Disable blending
				Gl.glDisable(Gl.GL_BLEND);
				
				// Swap buffers
				Glfw.glfwSwapBuffers();
			}
			
			// Disable sticky keys
			Glfw.glfwDisable(Glfw.GLFW_STICKY_KEYS);
		}
		
		/// <summary>
		/// DrawBox
		/// 
		/// Draw a 3D box
		/// </summary>
		/// <param name="x1">A  float</param>
		/// <param name="y1">A  float</param>
		/// <param name="z1">A  float</param>
		/// <param name="x2">A  float</param>
		/// <param name="y2">A  float</param>
		/// <param name="z2">A  float</param>
		public static void DrawBox(float x1, float y1, float z1, float x2, float y2, float z2) {
			float texScale = 4.0f;
			
			// Draw six sides of a cube
			Gl.glBegin(Gl.GL_QUADS);
			// Side 1 (down)
			Gl.glNormal3f(0.0f, 0.0f, -1.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x1, y2, z1);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x2, y2, z1);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x2, y1, z1);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x1, y1, z1);
			
			// Side 2 (up)
			Gl.glNormal3f(0.0f, 0.0f, 1.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x1, y1, z2);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x2, y1, z2);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x2, y2, z2);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x1, y2, z2);
			
			// Side 3 (backward)
			Gl.glNormal3f(0.0f, -1.0f, 0.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x1, y1, z1);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x2, y1, z1);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x2, y1, z2);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x1, y1, z2);
			
			// Side 4 (forward)
			Gl.glNormal3f(0.0f, 1.0f, 0.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x1, y2, z2);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x2, y2, z2);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x2, y2, z1);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x1, y2, z1);
			
			// Side 5 (left)
			Gl.glNormal3f(-1.0f, 0.0f, 0.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x1, y1, z2);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x1, y2, z2);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x1, y2, z1);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x1, y1, z1);
			
			// Side 6 (right)
			Gl.glNormal3f(1.0f, 0.0f, 0.0f);
			Gl.glTexCoord2f(0.0f, 0.0f);
			Gl.glVertex3f(x2, y1, z1);
			Gl.glTexCoord2f(texScale, 0.0f);
			Gl.glVertex3f(x2, y2, z1);
			Gl.glTexCoord2f(texScale, texScale);
			Gl.glVertex3f(x2, y2, z2);
			Gl.glTexCoord2f(0.0f, texScale);
			Gl.glVertex3f(x2, y1, z2);
			Gl.glEnd();
		}
		
		/// <summary>
		/// GameLoop
		/// </summary>
		static void GameLoop() {
			int playing;
			GameEvent gameEvent;
			
			// Initialize a new game
			NewGame();
			
			// Enable sticky keys
			Glfw.glfwEnable(Glfw.GLFW_STICKY_KEYS);
			
			// Loop until the game ends
			playing = Gl.GL_TRUE;
			while(playing == Gl.GL_TRUE && Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_TRUE) {
				// Frame timer
				oldTime = thisTime;
				thisTime = Glfw.glfwGetTime();
				dt = thisTime - oldTime;
				
				// Get user input and update player positions
				PlayerControl();
				
				// Move the ball, and check if a player hits/misses the ball
				gameEvent = BallControl();
				
				// Did we have a winner?
				switch(gameEvent) {
					case GameEvent.Player1Wins:
						winningPlayer = Player1.id;
						playing = Gl.GL_FALSE;
						break;
						
					case GameEvent.Player2Wins:
						winningPlayer = Player2.id;
						playing = Gl.GL_FALSE;
						break;
					default:
						break;
				}
				
				// Did the user press ESC?
				if(Glfw.glfwGetKey(Glfw.GLFW_KEY_ESC) == Gl.GL_TRUE) {
					playing = Gl.GL_FALSE;
				}
				
				// Did the user change camera view?
				if(Glfw.glfwGetKey('1') == Gl.GL_TRUE) {
					cameraPos = CameraPosition.Classic;
				}
				else if(Glfw.glfwGetKey('2') == Gl.GL_TRUE) {
					cameraPos = CameraPosition.Above;
				}
				else if(Glfw.glfwGetKey('3') == Gl.GL_TRUE) {
					cameraPos = CameraPosition.Spectator;
				}
				
				// Draw display
				UpdateDisplay();
				
				// Swap buffers
				Glfw.glfwSwapBuffers();
			}
			
			// Disable sticky keys
			Glfw.glfwDisable(Glfw.GLFW_STICKY_KEYS);
			
			// Show winner
			GameOver();
		}
		
		/// <summary>
		/// BallControl
		/// </summary>
		/// <returns>A GameEvent</returns>
		public static GameEvent BallControl() {
			GameEvent gameEvent;
			double ballspeed;
			
			// Calculate new ball speed
			ballspeed = ballSpeed * (1.0 + 0.02 * (thisTime - startTime));
			gameBall.speedX = gameBall.speedX > 0 ? ballspeed : -ballspeed;
			gameBall.speedY = gameBall.speedY > 0 ? ballspeed : -ballspeed;
			gameBall.speedY *= 0.74321;
			
			// Update ball position
			gameBall.posX += dt * gameBall.speedX;
			gameBall.posY += dt * gameBall.speedY;
			
			// Did the ball hit a top/bottom wall?
			if(gameBall.posY >= 1.0) {
				gameBall.posY = 2.0 - gameBall.posY;
				gameBall.speedY = -gameBall.speedY;
			}
			else if(gameBall.posY <= -1.0) {
				gameBall.posY = -2.0 - gameBall.posY;
				gameBall.speedY = -gameBall.speedY;
			}
			
			// Did the ball hit/miss a player?
			gameEvent = GameEvent.NobodyWins;
			
			// Is the ball entering the player 1 goal?
			if(gameBall.posX < -1.0 + playerSizeX) {
				// Did player 1 catch the ball?
				if(gameBall.posY > (Player1.posY - playerSizeY) &&
					 gameBall.posY < (Player1.posY + playerSizeY)) {
					gameBall.posX = -2.0 + 2.0 * playerSizeX - gameBall.posX;
					gameBall.speedX = -gameBall.speedX;
				}
				else {
					gameEvent = GameEvent.Player2Wins;
				}
			}
			
			// Is the ball entering the player 2 goal?
			if(gameBall.posX > 1.0 - playerSizeX) {
				// Did player 2 catch the ball?
				if(gameBall.posY > (Player2.posY - playerSizeY) &&
					 gameBall.posY < (Player2.posY + playerSizeY)) {
					gameBall.posX = 2.0 - 2.0 * playerSizeX - gameBall.posX;
					gameBall.speedX = -gameBall.speedX;
				}
				else {
					gameEvent = GameEvent.Player1Wins;
				}
			}
			
			return gameEvent;
		}
		
		/// <summary>
		/// Main
		/// 
		/// Program entry point
		/// </summary>
		public static void Run() {
			MenuOption menuoption;
			
			envAmbient     = new float[]{1.0f,1.0f,1.0f,1.0f};
			light1Position = new float[]{-3.0f,3.0f,2.0f,1.0f};
			light1Diffuse  = new float[]{1.0f,1.0f,1.0f,0.0f};
			light1Ambient  = new float[]{0.0f,0.0f,0.0f,0.0f};
			
			Player1Diffuse = new float[]{1.0f,0.3f,0.3f,1.0f};
			Player1Ambient = new float[]{0.3f,0.1f,0.0f,1.0f};
			Player2Diffuse = new float[]{0.3f,1.0f,0.3f,1.0f};
			Player2Ambient = new float[]{0.1f,0.3f,0.1f,1.0f};
			ballDiffuse    = new float[]{1.0f,1.0f,0.5f,1.0f};
			ballAmbient    = new float[]{0.3f,0.3f,0.1f,1.0f};
			borderDiffuse  = new float[]{0.3f,0.3f,1.0f,1.0f};
			borderAmbient  = new float[]{0.1f,0.1f,0.3f,1.0f};
			floorDiffuse   = new float[]{1.0f,1.0f,1.0f,1.0f};
			floorAmbient   = new float[]{0.3f,0.3f,0.3f,1.0f};
			
			Player1.id = 1;
			Player2.id = 2;
			
			// Initialize GLFW
			if(Glfw.glfwInit() == Gl.GL_FALSE) {
				System.Environment.Exit(0);
			}
			
			// Open OpenGL window
			if(Glfw.glfwOpenWindow(width, height, 0, 0, 0, 0, 16, 0, Glfw.GLFW_FULLSCREEN) == Gl.GL_FALSE) {
				Glfw.glfwTerminate();
				System.Environment.Exit(0);
			}
			
			// Load all textures
			LoadTextures();
			
			// Main loop
			do
			{
				// Get menu option
				menuoption = GameMenu();
				
				// If the user wants to play, let him...
				if(menuoption == MenuOption.Play) {
					GameLoop();
				}
			}
			while( menuoption != MenuOption.Quit );
			
			// Unload all textures
			if(Glfw.glfwGetWindowParam(Glfw.GLFW_OPENED) == Gl.GL_FALSE) {
				Gl.glDeleteTextures((int)Textures.Num_textures, TexId);
			}
			
			// Terminate GLFW
			Glfw.glfwTerminate();
			
		}
	}
}
