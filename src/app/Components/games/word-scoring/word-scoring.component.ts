import { Component } from '@angular/core';

@Component({
  selector: 'app-word-scoring',
  templateUrl: './word-scoring.component.html',
  styleUrls: ['./word-scoring.component.scss']
})
export class WordScoringComponent {

isVip : boolean = false ;

  wordList: WordList[] = [
    {
      word: "asd",
      score: 2022,
      date: new Date("2025-08-05")
    },
    {
      word: "asd",
      score: 20,
      date: new Date("2025-08-05")
    },
    {
      word: "asd",
      score: 20,
      date: new Date("2025-08-05")
    },
    // {
    //   word: "asd",
    //   score: 20,
    //   date: new Date("2025-08-05")
    // },
    // {
    //   word: "asd",
    //   score: 20,
    //   date: new Date("2025-08-05")
    // },
    // {
    //   word: "asd",
    //   score: 20,
    //   date: new Date("2025-08-05")
    // },
  
  ]

  convertStar(length : number ){

      return "*".repeat(length)

      


  }
}

interface WordList {
  word: string
  score: number
  date: Date


}
