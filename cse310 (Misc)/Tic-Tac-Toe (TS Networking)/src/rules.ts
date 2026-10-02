let turnO = true // Player O starts

const winPatterns: number[][] = [
  [0, 1, 2],
  [0, 3, 6],
  [0, 4, 8],
  [1, 4, 7],
  [2, 5, 8],
  [2, 4, 6],
  [3, 4, 5],
  [6, 7, 8],
]

let boxes: number[] = [0, 0, 0, 0, 0, 0, 0, 0, 0]

export function turn(boxId: number): number {
  if (turnO) {
    if (boxes[boxId - 1] != 0) {
      return 0
    }
    boxes[boxId - 1] = 2
    turnO = false
    return 1
  } else {
    if (boxes[boxId - 1] != 0) {
      return 0
    }
    boxes[boxId - 1] = 1
    turnO = true
    return 2
  }
}

export function checkWinner(): number {
  let hasWin: boolean = false
  for (let pattern of winPatterns) {
    let pos1Val: number = Number(boxes[Number(pattern[0])])
    let pos2Val: number = Number(boxes[Number(pattern[1])])
    let pos3Val: number = Number(boxes[Number(pattern[2])])

    if (
      pos1Val !== 0 && 
      pos2Val !== 0 &&
      pos3Val !== 0 &&
      pos1Val === pos2Val &&
      pos2Val === pos3Val
    ) {

      hasWin = true
      return pos1Val

    }
  }

  if (!hasWin) {
    const allBoxes: boolean = boxes.every((box) => box !== 0)
    if (allBoxes) {
      return 0
    }
  }

  return 100
}

export function clearAll(): void {
  turnO = true
  boxes = [0, 0, 0, 0, 0, 0, 0, 0, 0]
}