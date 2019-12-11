<Query Kind="Statements" />

/*The first floor contains a polonium generator, a thulium generator, a thulium-compatible microchip, a promethium generator, a ruthenium generator, a ruthenium-compatible microchip, a cobalt generator, and a cobalt-compatible microchip.
The second floor contains a polonium-compatible microchip and a promethium-compatible microchip.
The third floor contains nothing relevant.
The fourth floor contains nothing relevant.
*/

// Solve with math (PART A)
// It requires moves of 2x - 3 for each item on each floor to move it to the next floor (the last couple items get to move together)
// Floor 1 to floor 2 (2 * 8 - 3) for 13
// Floor 2 to floor 3 (2 * 10 - 3) for 17
// Floor 3 to floor 4 (2 * 10 - 3) for 17
// Total 47

// Solve with math (PART B)
// It requires moves of 2x - 3 for each item on each floor to move it to the next floor (the last couple items get to move together)
// Floor 1 to floor 2 (2 * 12 - 3) for 21
// Floor 2 to floor 3 (2 * 14 - 3) for 25
// Floor 3 to floor 4 (2 * 14 - 3) for 25
// Total 71