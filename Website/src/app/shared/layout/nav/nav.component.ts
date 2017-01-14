import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.scss']
})
export class NavComponent implements OnInit {
  showNavigationLinks: boolean = false;

  constructor(private router: Router) {
  }

  ngOnInit() {
    this.router.events.subscribe(() => {
      this.showNavigationLinks = false;
    });
  }

  toggleNavigationLinks() {
    this.showNavigationLinks = !this.showNavigationLinks;
  }
}
