using System;
using System.Collections.Generic;

namespace RobotBoundedInCircle {
    //On an infinite plane, a robot initially stands at (0, 0) and faces north. Note that:

    // -The north direction is the positive direction of the y-axis.
    // -The south direction is the negative direction of the y-axis.
    // -The east direction is the positive direction of the x-axis.
    // -The west direction is the negative direction of the x-axis.

    //The robot can receive one of three instructions:

    // -"G": go straight 1 unit.
    // -"L": turn 90 degrees to the left(i.e., anti-clockwise direction).
    // -"R": turn 90 degrees to the right(i.e., clockwise direction).
    // -The robot performs the instructions given in order, and repeats them forever.

    //Return true if and only if there exists a circle in the plane such that the robot never leaves the circle.

    //Example 1:

    //Input: instructions = "GGLLGG"
    //Output: true
    //Explanation:
    //The robot is initially at (0, 0) facing the north direction.
    //"G": move one step.Position: (0, 1). Direction: North.
    //"G": move one step.Position: (0, 2). Direction: North.
    //"L": turn 90 degrees anti-clockwise.Position: (0, 2). Direction: West.
    //"L": turn 90 degrees anti-clockwise.Position: (0, 2). Direction: South.
    //"G": move one step.Position: (0, 1). Direction: South.
    //"G": move one step.Position: (0, 0). Direction: South.
    //Repeating the instructions, the robot goes into the cycle: (0, 0) --> (0, 1) --> (0, 2) --> (0, 1) --> (0, 0).
    //Based on that, we return true.
    //Example 2:

    //Input: instructions = "GG"
    //Output: false
    //Explanation:
    //The robot is initially at(0, 0) facing the north direction.
    //"G": move one step.Position: (0, 1). Direction: North.
    //"G": move one step.Position: (0, 2). Direction: North.
    //Repeating the instructions, keeps advancing in the north direction and does not go into cycles.
    //Based on that, we return false.
    //Example 3:

    //Input: instructions = "GL"
    //Output: true
    //Explanation:
    //The robot is initially at(0, 0) facing the north direction.
    //"G": move one step.Position: (0, 1). Direction: North.
    //"L": turn 90 degrees anti-clockwise.Position: (0, 1). Direction: West.
    //"G": move one step.Position: (-1, 1). Direction: West.
    //"L": turn 90 degrees anti-clockwise.Position: (-1, 1). Direction: South.
    //"G": move one step.Position: (-1, 0). Direction: South.
    //"L": turn 90 degrees anti-clockwise.Position: (-1, 0). Direction: East.
    //"G": move one step.Position: (0, 0). Direction: East.
    //"L": turn 90 degrees anti-clockwise.Position: (0, 0). Direction: North.
    //Repeating the instructions, the robot goes into the cycle: (0, 0) --> (0, 1) --> (-1, 1) --> (-1, 0) --> (0, 0).
    //Based on that, we return true.

    //Constraints:

    //1 <= instructions.length <= 100
    //instructions[i] is 'G', 'L' or, 'R'.

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(IsRobotBounded("GGLLGG")); //Expected: true
            Console.WriteLine(IsRobotBounded("GG")); //Expected: false
            Console.WriteLine(IsRobotBounded("GL")); //Expected: true
            Console.WriteLine(IsRobotBounded("LLGRL")); //Expected: true
            Console.WriteLine(IsRobotBounded("GLGLGGLGL")); //Expected: false            
        }

        public static bool IsRobotBounded(string instructions) {
            //positions
            int x = 0, y = 0;

            //directions
            int north = 0, west = 3, current = 0; //east = 1, south = 2  

            List<List<int>> moves = new List<List<int>>(){
            new List<int>() {0,1},  // N
            new List<int>() {1,0},  // E
            new List<int>() {0,-1}, // S
            new List<int>() {-1,0}  // W
            };

            foreach (var item in instructions) {
                if (item == 'G') {
                    x += moves[current][0]; //matrix[row][column] 
                    y += moves[current][1];
                } else if (item == 'R') {
                    current++;
                    if (current > west) {
                        current = north;
                    }
                } else if (item == 'L') {
                    current--;
                    if (current < north) {
                        current = west;
                    }
                }
            }

            if ((x == 0 && y == 0) || (current != 0)) { //if is at initial position OR is not at initial direction (north) return true
                return true;
            }

            return false;
        }

        public static bool IsRobotBounded2(string instructions) {
            char currentDir = 'N';
            int xPos = 0;
            int yPos = 0;

            foreach (var item in instructions) {
                if (item == 'G') {
                    if (currentDir == 'N') {
                        yPos++;
                    } else if (currentDir == 'S') {
                        yPos--;
                    } else if (currentDir == 'E') {
                        xPos++;
                    } else if (currentDir == 'W') {
                        xPos--;
                    }
                } else if (item == 'L') {
                    if (currentDir == 'N') {
                        currentDir = 'W';
                    } else if (currentDir == 'S') {
                        currentDir = 'E';
                    } else if (currentDir == 'E') {
                        currentDir = 'N';
                    } else if (currentDir == 'W') {
                        currentDir = 'S';
                    }
                } else if (item == 'R') {
                    if (currentDir == 'N') {
                        currentDir = 'E';
                    } else if (currentDir == 'S') {
                        currentDir = 'W';
                    } else if (currentDir == 'E') {
                        currentDir = 'S';
                    } else if (currentDir == 'W') {
                        currentDir = 'N';
                    }
                }
            }

            if (xPos == 0 & yPos == 0 | currentDir != 'N') {
                return true;
            }

            return false;
        }

        public static bool IsRobotBounded3(string instructions) {
            char currentDir = 'N';
            int xPos = 0;
            int yPos = 0;

            foreach (var item in instructions) {
                if (item == 'G') {
                    yPos += currentDir == 'N' ? 1 : 0;
                    yPos += currentDir == 'S' ? -1 : 0;
                    xPos += currentDir == 'E' ? 1 : 0;
                    xPos += currentDir == 'W' ? -1 : 0;
                } else {
                    if (currentDir == 'N') {
                        currentDir = item == 'L' ? 'W' : 'E';
                    } else if (currentDir == 'S') {
                        currentDir = item == 'L' ? 'E' : 'W';
                    } else if (currentDir == 'E') {
                        currentDir = item == 'L' ? 'N' : 'S';
                    } else if (currentDir == 'W') {
                        currentDir = item == 'L' ? 'S' : 'N';
                    }
                }
            }                                    

            if (xPos == 0 & yPos == 0 | currentDir != 'N') {    //bool direction = currentDir == 'N' ? false : true;
                return true;                                    //bool position = (xPos == 0 & yPos == 0) ? true : false;                
            }                                                   //return position | direction;

            return false;
        }

        public static bool IsRobotBounded4(string instructions) {
            int dirUp = 0;
            int dirLeft = 1;
            int dirDown = 2;
            int dirRight = 3;
            int dirInitial = dirUp;
            int dirCurrent = dirInitial;

            int posX = 0;
            int posY = 0;            

            foreach (var item in instructions) {
                if (item == 'G') {
                    if (dirCurrent == dirUp) {
                        posY--;
                    } else if (dirCurrent == dirDown) {
                        posY++;
                    } else if (dirCurrent == dirLeft) {
                        posX--;
                    } else if (dirCurrent == dirRight) {
                        posX++;
                    }
                } else if (item == 'L') {
                    dirCurrent++;
                    if (dirCurrent > dirRight) {
                        dirCurrent = dirUp;
                    }
                } else if (item == 'R') {
                    dirCurrent--;
                    if (dirCurrent < dirUp) {
                        dirCurrent = dirRight;
                    }
                }
            }
            
            bool direction = dirCurrent == dirInitial ? false : true;
            bool position = (posX == 0 & posY == 0) ? true : false;

            return position | direction;
        }

        public static bool IsRobotBounded5(string instructions) {
            int dirX = 0;
            int dirY = 1;

            int posX = 0;
            int posY = 0;            

            foreach (var item in instructions) {
                if (item == 'G') {
                    posX = posX + dirX;
                    posY = posY + dirY;
                } else if (item == 'L') {
                    int temp = dirY * -1;
                    dirY = dirX;
                    dirX = temp;
                } else {
                    int temp = dirY;
                    dirY = dirX * -1;
                    dirX = temp;
                }
            }

            bool position = (posX == 0 & posY == 0) ? true : false;
            bool direction = (dirX == 0 & dirY == 1) ? false : true;

            return position | direction; //return (posX == 0 & posY == 0) | (dirX != 0 | dirY != 1);
        }

        public static bool IsRobotBounded6(string instructions) {            
            List<List<int>> moves = new List<List<int>>(){
                                                        new List<int>(){0,1},   // N
                                                        new List<int>(){-1,0},  // E 
                                                        new List<int>(){0,-1},  // S
                                                        new List<int>(){1,0}    // W
                                                        };
            int xPos = 0, yPos = 0, currentDir = 0;

            foreach (var item in instructions) {
                if (item == 'G') {
                    xPos += moves[currentDir][0];
                    yPos += moves[currentDir][1];
                } else if (item == 'L') {
                    currentDir = (currentDir + 3) % 4;
                } else if (item == 'R') {
                    currentDir = (currentDir + 1) % 4;
                }
            }

            if (xPos == 0 && yPos == 0 || currentDir != 0) {
                return true;
            }

            return false;
        }
    }
}
