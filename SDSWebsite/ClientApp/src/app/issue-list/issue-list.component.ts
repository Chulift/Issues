import { Component, OnInit } from '@angular/core';

import { Issue } from '../issue';
import { IssueService } from '../issue.service';

@Component({
  selector: 'app-issue-list',
  templateUrl: './issue-list.component.html',
  styleUrls: ['./issue-list.component.css']
})
export class IssueListComponent implements OnInit {

  issue: Issue;

  constructor(
    private issueService: IssueService
  ) { }

  ngOnInit() {
    this.getIssue();
  }

  getIssue(): void {
    this.issueService.getIssue(1)
      .subscribe(issue => this.issue = issue);
  }

}
