        private void LoadBoats()
        {
            // Load data. Check the boats activitylevel on a 8-day-basis
            DateTime limit = DateTime.Now.AddDays(-8);

            this._boats = (from boat in db.Boat
                where boat.Active
                orderby boat.Trips.Any(trip => trip.TripEndedTime == null),
                    boat.Trips.Count(trip => trip.TripStartTime > limit) descending
                select boat)
                .Include(boat => boat.Trips)
                .ToList();
        }