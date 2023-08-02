import React from 'react';
import { RequestItem } from './RequestItem';
import { AnnouncementItem } from './AnnouncementItem';
import { Schedule } from './Schedule';

const HomePage = () => {
  return (
    <div className="h-full bg-red-200 p-5">
      <div className="h-1/2 bg-white rounded-t-xl">
        <div className="flex justify-between items-center h-full">
          <div className="w-2/3 text-center bg-green-200 p-1 rounded-tl-xl h-full">
            <RequestItem />
          </div>
          <div className="w-1/3 text-center bg-cyan-200 p-1 rounded-tr-xl h-full">
            <AnnouncementItem />
          </div>
        </div> 
      </div>
      <div className="text-center p-1 h-1/2 bg-slate-300 rounded-b-xl">
        <Schedule />
      </div>
    </div>
  );
};

export default HomePage;
