import { Component, OnInit } from '@angular/core';
import { HiveSection } from '../models/hive-section';
import { ActivatedRoute, Router } from '@angular/router';
import { HiveSectionService } from '../services/hive-section.service';
import { HiveSectionListItem } from '../models/hive-section-list-item';
import { HiveService } from '../services/hive.service';
import { HiveListItem } from '../models/hive-list-item';
import { Hive } from '../models/hive';

@Component({
  selector: 'app-hive-section-form',
  templateUrl: './hive-section-form.component.html',
  styleUrls: ['./hive-section-form.component.css']
})
export class HiveSectionFormComponent implements OnInit {

  section = new HiveSection(0, "Add new section name", "SOME1", false, "");
  existed = false;
  sectionId: number;
  hiveSections: HiveSectionListItem[];
  hives: HiveListItem[];
  hive = this.sectionId;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private sectionService: HiveSectionService,
    private hiveService: HiveService
  ) { }

  ngOnInit() {
    this.sectionService.getHiveSections().subscribe(c => this.hiveSections = c);
    this.route.params.subscribe(p => {
      this.sectionId = p['sectionId'];
      if (p['id'] === undefined) return;
      this.sectionService.getHiveSection(p['id']).subscribe(c => this.section = c);
      this.existed = true;
    });
  }
  navigateTo() {
    if (this.sectionId === undefined) {
      this.router.navigate(['/hives']);
    } else {
      this.router.navigate([`/hive/${this.sectionId}/sections`]);
    }
  }

  onCancel() {
    this.navigateTo();
  }
  
  onSubmit() {
    if (this.existed) {
      this.sectionService.updateHiveSection(this.section).subscribe(p => this.navigateTo());
    } else {
      this.section.id = this.sectionId;
      this.sectionService.addHiveSection(this.section).subscribe(p => this.navigateTo());
    }
  }

  onDelete() {
    this.sectionService.setHiveSectionStatus(
      this.section.id, true).subscribe
      (c => this.section.isDeleted = true);
  }

  onUndelete() {
    this.sectionService.setHiveSectionStatus(
      this.section.id, false).subscribe
      (c => this.section.isDeleted = false);
  }

  onPurge() {
    this.sectionService.deleteHiveSection(
      this.section.id).subscribe
      (c => this.navigateTo());
  }
}
